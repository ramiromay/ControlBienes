using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.EstadoGeneral;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Genericos;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System.Linq.Expressions;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.EstadoGeneral
{
    public class BusEstadoGeneral : IBusEstadoGeneral
    {
        private readonly IDatEstadoGeneral _repositorio;
        private readonly ILogger<BusEstadoGeneral> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntEstadoGeneralRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkEstadoGeneral;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorEstadoGeneral;

        public BusEstadoGeneral(IDatEstadoGeneral repositorio, IMapper mapper, ILogger<BusEstadoGeneral> logger,
            IValidator<EntEstadoGeneralRequest> validator)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntEstadoGeneralRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntEstadoGeneralRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar el estado general");
            try
            {
                BValidarRequest(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.sNombre = request.Nombre;
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
                    "Ocurrio un error al intentar actualiza el estado general"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del estado general");
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
                    "Ocurrio un error al intentar actualizar el estatus del estado general"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntEstadoGeneralRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un estado general");
            try
            {
                BValidarRequest(request);
                var entidad = _mapper.Map<EntEstadoGeneral>(request);
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
                    "Ocurrio un error al intentar crear el estado general"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntEstadoGeneralResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntEstadoGeneralResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el estado general");
            try
            {
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntEstadoGeneralResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntEstadoGeneralResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar el estado general"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntEstadoGeneralResponse>>> BObtenerTodosAsync(bool? activo)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntEstadoGeneralResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los estados generales");
			try
            {
				Expression<Func<EntEstadoGeneral, bool>>? predicado = activo.HasValue
                    ? r => r.bActivo == activo.Value
                    : null;

				var entidades = await _repositorio.DObtenerTodosAsync(predicado: predicado);
                resultado.Result = _mapper.Map<IEnumerable<EntEstadoGeneralResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntEstadoGeneralResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los estados generales"
                );
            }

            return resultado;
        }
    }
}
