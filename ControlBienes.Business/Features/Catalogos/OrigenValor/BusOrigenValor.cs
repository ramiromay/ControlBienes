using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.OrigenValor;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.OrigenValor
{
    public class BusOrigenValor : IBusOrigenValor
    {

        private readonly IDatOrigenValor _repositorio;
        private readonly ILogger<BusOrigenValor> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntOrigenValorRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkOrigenValor;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorOrigenValor;

        public BusOrigenValor(IDatOrigenValor repositorio, IMapper mapper, ILogger<BusOrigenValor> logger,
            IValidator<EntOrigenValorRequest> validator)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntOrigenValorRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntOrigenValorRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar el origen");
            try
            {
                BValidarRequest(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.sOrigen = request.Origen;
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
                    "Ocurrio un error al intentar actualiza el origen"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del origen");
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
                    "Ocurrio un error al intentar actualizar el estatus del origen"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntOrigenValorRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear el origen");
            try
            {
                BValidarRequest(request);
                var entidad = _mapper.Map<EntOrigenValor>(request);
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
                    "Ocurrio un error al intentar crear el origen"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntOrigenValorResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntOrigenValorResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el origen");
            try
            {
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntOrigenValorResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntOrigenValorResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar el origen"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntOrigenValorResponse>>> BObtenerTodosAsync()
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntOrigenValorResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los origenes del valor");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync();
                resultado.Result = _mapper.Map<IEnumerable<EntOrigenValorResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntOrigenValorResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los origenes del valor"
                );
            }

            return resultado;
        }
    }
}
