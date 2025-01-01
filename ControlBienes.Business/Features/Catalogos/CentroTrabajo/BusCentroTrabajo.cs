using AutoMapper;
using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.CentroTrabajo;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.CentroTrabajo
{
	public class BusCentroTrabajo : IBusCentroTrabajo
    {
        private readonly IDatCentroTrabajo _repositorio;
        private readonly IDatPeriodo _repositorioPeriodo;
        private readonly IDatMunicipio _repositorioMunicipio;
        private readonly IDatUnidadAdministrativa _repositorioUnidadAdministrativa;
        private readonly ILogger<BusCentroTrabajo> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntCentroTrabajoRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkCentroTrabajo;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorCentroTrabajo;

        public BusCentroTrabajo(IDatCentroTrabajo repositorio, IDatPeriodo respositorioPeriodo, IDatMunicipio repositorioMunicipio,
            IDatUnidadAdministrativa repoitorioUnidadAdministrativa, IMapper mapper, ILogger<BusCentroTrabajo> logger,
            IValidator<EntCentroTrabajoRequest> validator)
        {
            _repositorio = repositorio;
            _repositorioPeriodo = respositorioPeriodo;
            _repositorioMunicipio = repositorioMunicipio;
            _repositorioUnidadAdministrativa = repoitorioUnidadAdministrativa;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntCentroTrabajoRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        private async Task BValidadRequestBD(EntCentroTrabajoRequest request)
        {
            var existePeriodo = await _repositorioPeriodo.DExisteRegistroAsync(e => e.iIdPeriodo ==  request.IdPeriodo);
            var existeMunicipio = await _repositorioMunicipio.DExisteRegistroAsync(e => e.iIdMunicipio == request.IdMunicipio);
            var existeUnidadAdministrativa = await _repositorioUnidadAdministrativa.DExisteRegistroAsync(e => e.iIdUnidadAdministrativa == request.IdUnidadAdministrativa);

            string errores = "";
            if (!existePeriodo) errores += "El Periodo no se encuentra registrado,";
            if (!existeMunicipio) errores += "El Municipio no se encuentra registrado,";
            if (!existeUnidadAdministrativa) errores += "La Unidad Administrativa no se encuentra registrada";
            if (string.IsNullOrEmpty(errores)) return;
            errores = BusConvertirErrors.URemoverComillaFinal(errores);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        } 

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntCentroTrabajoRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un centro de trabajo");
            try
            {
                BValidarRequest(request);
                await BValidadRequestBD(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.iIdPeriodo = request.IdPeriodo.Value;
                entidad.sNombre = request.Nombre;
                entidad.sClave = request.Clave;
                entidad.sDireccion = request.Direccion;
                entidad.iIdMunicipio = request.IdMunicipio.Value;
                entidad.iIdUnidadAdministrativa = request.IdUnidadAdministrativa.Value;
                resultado.Result = await _repositorio.DActualizarAsync(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<int>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar actualiza el centro de trabajo"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus de un centro de trabajo");
            try
            {
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = await _repositorio.DActualizarEstatusAsync(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<int>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar actualizar el estatus de un centro de trabajo"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntCentroTrabajoRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un centro de trabajo");
            try
            {
                BValidarRequest(request);
                await BValidadRequestBD(request);
                var entidad = _mapper.Map<EntCentroTrabajo>(request);
                resultado.Result = await _repositorio.DCrearAsync(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<int>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar crear el centro de trabajo"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntCentroTrabajoResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntCentroTrabajoResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el turno del centro de trabajo");
            try
            {
                var includes = new List<Expression<Func<EntCentroTrabajo, object>>>()
                {
                    f => f.Municipio!,
                    f => f.UnidadAdministrativa!
                };
                var entidad = await _repositorio.DObtenerRegistroAsync(e => e.iIdCentroTrabajo == id, includes)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntCentroTrabajoResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntCentroTrabajoResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar el turno del centro de trabajo"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntCentroTrabajoResponse>>> BObtenerTodosAsync(bool? activo)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntCentroTrabajoResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los turnos del centros de trabajo");
            try
            {
				Expression<Func<EntCentroTrabajo, bool>>? predicado = activo.HasValue
					? r => r.bActivo == activo.Value
					: null;

				var includes = new List<Expression<Func<EntCentroTrabajo, object>>>()
                {
                    f => f.Municipio!,
                    f => f.UnidadAdministrativa!
                };
                var entidades = await _repositorio.DObtenerTodosAsync(incluir: includes, predicado: predicado);
                resultado.Result = _mapper.Map<IEnumerable<EntCentroTrabajoResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntCentroTrabajoResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los turnos centros de trabajo"
                );
            }

            return resultado;
        }
    }
}
