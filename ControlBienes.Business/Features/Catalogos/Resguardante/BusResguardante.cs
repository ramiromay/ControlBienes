using AutoMapper;
using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.CentroTrabajoTurno;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.CentroTrabajo;
using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;
using ControlBienes.Entities.Catalogos.Resguardante;
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

namespace ControlBienes.Business.Features.Catalogos.Resguardante
{
    public class BusResguardante : IBusCatalogo<EntResguardanteRequest, EntResguardanteResponse>, IBusResguardante
    {
        private readonly IDatResguardante _repositorio;
        private readonly IDatPeriodo  _repositorioPeriodo;
        private readonly IDatUnidadAdministrativa _repositorioUnidadAdministrativa;
        private readonly IDatPersona _respositorioPersona;
        private readonly IDatTipoResponsable _repositorioTipoResponsable;
        private readonly ILogger<BusResguardante> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntResguardanteRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkResguardante;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorResguardante;

        public BusResguardante(IDatResguardante repositorio, IDatPeriodo repositorioPeriodo,
            IDatUnidadAdministrativa repositorioUnidadAdministrativa, IDatPersona respositorioPersona,
            IDatTipoResponsable repositorioTipoResponsable, IMapper mapper, ILogger<BusResguardante> logger,
            IValidator<EntResguardanteRequest> validator)
        {
            _repositorio = repositorio;
            _repositorioPeriodo = repositorioPeriodo;
            _repositorioUnidadAdministrativa = repositorioUnidadAdministrativa;
            _respositorioPersona = respositorioPersona;
            _repositorioTipoResponsable = repositorioTipoResponsable;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntResguardanteRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        private async Task BValidarRequestBD(EntResguardanteRequest request)
        {
            var existePeriodo = await _repositorioPeriodo.DExisteRegistroAsync(e => e.iIdPeriodo == request.IdPeriodo);
            var existeUnidadAdministrativa = await _repositorioUnidadAdministrativa.DExisteRegistroAsync(e => e.sNivelCompleto == request.NivelUnidadAdministrativa);
            var existeePersona = await _respositorioPersona.DExisteRegistroAsync(e => e.iIdPersona == request.IdPersona);
            var existeTipoResponsable = await _repositorioTipoResponsable.DExisteRegistroAsync(e => e.iIdTipoResponsable == request.IdTipoResponsable);

            string errores = "";
            if (!existePeriodo) errores += "El Periodo no se encuentra registrado,";
            if (!existeePersona) errores +=  "La Persona no se encuentra registrada,";
            if (!existeTipoResponsable) errores  += "El Tipo Responsable no se encuentra registrado,";
            if (!existeUnidadAdministrativa) errores += "La Unidad Administrativa no se encuentra registrada";
            if (string.IsNullOrEmpty(errores)) return;
            errores = BusConvertirErrors.URemoverComillaFinal(errores);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntResguardanteRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un resguardante");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var unidadAdministrativa = await _repositorioUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == request.NivelUnidadAdministrativa);
                entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
				entidad.iIdPeriodo = request.IdPeriodo.Value;
                entidad.iIdPersona = request.IdPersona.Value;
                entidad.iIdTipoResponsable = request.IdTipoResponsable.Value;
                entidad.iNoConvenio = request.NoConvenio.Value;
                entidad.sObservaciones = request.Observaciones;
                entidad.bResponsable = request.Responsable;
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
                    "Ocurrio un error al intentar actualiza el resguardante"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus de un resguardante");
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
                    "Ocurrio un error al intentar actualizar el estatus de un resguardante"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntResguardanteRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un resguardante");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request);
                var entidad = _mapper.Map<EntResguardante>(request);
                var unidadAdministrativa = await _repositorioUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == request.NivelUnidadAdministrativa);
                entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;

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
                    "Ocurrio un error al intentar crear el resguardante"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntResguardanteResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntResguardanteResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el resguardante");
            try
            {
                var includes = new List<Expression<Func<EntResguardante, object>>>()
                {
                    f => f.Periodo!,
                    f => f.Persona!,
                    f => f.TipoResponsable!,
                    f => f.UnidadAdministrativa!
                };
                var entidad = await _repositorio.DObtenerRegistroAsync(e => e.iIdResguardante == id, includes)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntResguardanteResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntResguardanteResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar el resguardante"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntResguardanteResponse>>> BObtenerTodosAsync(bool? activo)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntResguardanteResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los resguardantes");
            try
            {
				Expression<Func<EntResguardante, bool>>? predicado = activo.HasValue
                    ? r => r.bActivo == activo.Value
                    : null;
				var includes = new List<Expression<Func<EntResguardante, object>>>()
                {
                    f => f.Periodo!,
                    f => f.Persona!,
                    f => f.TipoResponsable!,
                    f => f.UnidadAdministrativa!
                };
                var entidades = await _repositorio.DObtenerTodosAsync(incluir: includes, predicado: predicado);
                resultado.Result = _mapper.Map<IEnumerable<EntResguardanteResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntResguardanteResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los resguardantes"
                );
            }

            return resultado;
        }
    }
}
