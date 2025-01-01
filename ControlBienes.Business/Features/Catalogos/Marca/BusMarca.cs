using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.Marca;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.Marca
{
    public class BusMarca : IBusMarca
    {
        private readonly IDatMarca _repositorio;
        private readonly ILogger<BusMarca> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntMarcaRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkMarca;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorMarca;

        public BusMarca(IDatMarca repositorio, IMapper mapper, ILogger<BusMarca> logger,
            IValidator<EntMarcaRequest> validator)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntMarcaRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntMarcaRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar la marca");
            try
            {
                BValidarRequest(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.sNombre = request.Nombre;
                entidad.sObservaciones = request.Observaciones;
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
                    "Ocurrio un error al intentar actualiza la marca"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus de la marca");
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
                    "Ocurrio un error al intentar actualizar el estatus de la marca"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntMarcaRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear la marca");
            try
            {
                BValidarRequest(request);
                var entidad = _mapper.Map<EntMarca>(request);
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
                    "Ocurrio un error al intentar crear la marca"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntMarcaResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntMarcaResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar la marca");
            try
            {
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntMarcaResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntMarcaResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar la marca"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntMarcaResponse>>> BObtenerTodosAsync(bool? activo)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntMarcaResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas la marcas");
            try
            {
				Expression<Func<EntMarca, bool>>? predicado = activo.HasValue
                    ? r => r.bActivo == activo.Value
                    : null;
				var entidades = await _repositorio.DObtenerTodosAsync(predicado: predicado);
                resultado.Result = _mapper.Map<IEnumerable<EntMarcaResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntMarcaResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todas las marcas"
                );
            }

            return resultado;
        }
    }
}
