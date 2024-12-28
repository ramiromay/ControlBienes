using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.Ubicacion;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.Ubicacion
{
    public class BusUbicacion : IBusUbicacion
    {
        private readonly IDatUbicacion _repositorio;
        private readonly ILogger<BusUbicacion> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntUbicacionRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkColor;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorColor;

        public BusUbicacion(IDatUbicacion repositorio, IMapper mapper, ILogger<BusUbicacion> logger,
            IValidator<EntUbicacionRequest> validator)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntUbicacionRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntUbicacionRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar la ubicacion");
            try
            {
                BValidarRequest(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.sDescripcion = request.Descripcion;
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
                    "Ocurrio un error al intentar actualiza la ubicacion"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus de la ubicacion");
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
                    "Ocurrio un error al intentar actualizar el estatus de la ubicacion"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntUbicacionRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear una ubicacion");
            try
            {
                BValidarRequest(request);
                var entidad = _mapper.Map<EntUbicacion>(request);
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
                    "Ocurrio un error al intentar crear la ubicacion"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntUbicacionResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntUbicacionResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar la ubicacion");
            try
            {
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntUbicacionResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntUbicacionResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar la ubicacion"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntUbicacionResponse>>> BObtenerTodosAsync()
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntUbicacionResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las ubicaciones");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync();
                resultado.Result = _mapper.Map<IEnumerable<EntUbicacionResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntUbicacionResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todas las ubicaciones"
                );
            }

            return resultado;
        }
    }
}
