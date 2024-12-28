using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.UsoInmueble;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.UsoInmueble
{
    public class BusUsoInmueble : IBusUsoInmueble
    {
        private readonly IDatUsoInmueble _repositorio;
        private readonly ILogger<BusUsoInmueble> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntUsoInmuebleRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkUsoInmueble;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorUsoInmueble;

        public BusUsoInmueble(IDatUsoInmueble repositorio, IMapper mapper, ILogger<BusUsoInmueble> logger,
            IValidator<EntUsoInmuebleRequest> validator)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntUsoInmuebleRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntUsoInmuebleRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar el uso inmueble");
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
                    "Ocurrio un error al intentar actualiza el uso inmueble"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del uso inmueble");
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
                    "Ocurrio un error al intentar actualizar el estatus del uso inmueble"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntUsoInmuebleRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un uso de inmueble");
            try
            {
                BValidarRequest(request);
                var entidad = _mapper.Map<EntUsoInmueble>(request);
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
                    "Ocurrio un error al intentar crear el uso de inmueble"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntUsoInmuebleResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntUsoInmuebleResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el uso de inmueble");
            try
            {
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntUsoInmuebleResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntUsoInmuebleResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar el uso de inmueble"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntUsoInmuebleResponse>>> BObtenerTodosAsync()
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntUsoInmuebleResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los usos del inmueble");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync();
                resultado.Result = _mapper.Map<IEnumerable<EntUsoInmuebleResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntUsoInmuebleResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los usos del inmueble"
                );
            }

            return resultado;
        }
    }
}
