using AutoMapper;
using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Titular;
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

namespace ControlBienes.Business.Features.Catalogos.Titular
{
    public class BusTitular : IBusTitular
    {

        private readonly IDatTitular _repositorio;
        private readonly IDatCentroTrabajoTurno _repositorioCentroTrabajoTurno;
        private readonly ILogger<BusTitular> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntTitularRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTitular;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTitular;

        public BusTitular(IDatTitular repositorio, IDatCentroTrabajoTurno repositorioCentroTrabajoTurno, IMapper mapper, 
            ILogger<BusTitular> logger, IValidator<EntTitularRequest> validator)
        {
            _repositorio = repositorio;
            _repositorioCentroTrabajoTurno = repositorioCentroTrabajoTurno;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntTitularRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        private async Task BValidarRequestBD(EntTitularRequest request)
        {
            var existeCentroTrabajoTurno = await _repositorioCentroTrabajoTurno.DExisteRegistroAsync(e => e.iIdCentroTrabajoTurno == request.IdCentroTrabajoTurno);

            string errores = "";
            if (!existeCentroTrabajoTurno) errores = "El Centro de Trabajo asosciado al Turno no se encuentra registrado";
            if (string.IsNullOrEmpty(errores)) return;
            errores = BusConvertirErrors.URemoverComillaFinal(errores);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntTitularRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un titular");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.sNombre = request.Nombre;
                entidad.iIdCentroTrabajoTurno = request.IdCentroTrabajoTurno.Value;
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
                    "Ocurrio un error al intentar actualiza el titular"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del titular");
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
                    "Ocurrio un error al intentar actualizar el estatus del color"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntTitularRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un titular");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request);
                var entidad = _mapper.Map<EntTitular>(request);
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
                    "Ocurrio un error al intentar crear el titular"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntTitularResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntTitularResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el titular");
            try
            {
                var includes = new List<Expression<Func<EntTitular, object>>>()
                {
                    f => f.CentroTrabajoTurno.CentroTrabajo!,
                    f => f.CentroTrabajoTurno.Turno!,
                };
                var entidad = await _repositorio.DObtenerRegistroAsync(e => e.iIdTitular == id, includes)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntTitularResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntTitularResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar el titular"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntTitularResponse>>> BObtenerTodosAsync(bool? activo)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntTitularResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los titulares");
            try
            {
				Expression<Func<EntTitular, bool>>? predicado = activo.HasValue
                    ? r => r.bActivo == activo.Value
                    : null;
				var includes = new List<Expression<Func<EntTitular, object>>>()
                {
                    f => f.CentroTrabajoTurno.CentroTrabajo!,
                    f => f.CentroTrabajoTurno.Turno!,
                };
                var entidades = await _repositorio.DObtenerTodosAsync(incluir: includes, predicado: predicado);
                resultado.Result = _mapper.Map<IEnumerable<EntTitularResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntTitularResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los titulares"
                );
            }

            return resultado;
        }
    }
}
