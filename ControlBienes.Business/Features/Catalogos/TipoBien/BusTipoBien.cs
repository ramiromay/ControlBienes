using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.TipoBien
{
    public class BusTipoBien : IBusTipoBien
    {

        private readonly IDatTipoBien _repositorio;
        private readonly IMapper _mapper;
        private readonly ILogger<BusTipoBien> _logger;
        private readonly IValidator<EntTipoBienRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTipoBien;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTipoBien;

        public BusTipoBien(IDatTipoBien repositorio, IMapper mapper, ILogger<BusTipoBien> logger, IValidator<EntTipoBienRequest> validator)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntTipoBienRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            string errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntTipoBienRequest request)
        {
            string nombreMetodo = nameof(this.BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar el tipo de bien");
            try
            {
                BValidarRequest(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.sNombre = request.Nombre!;
                resultado.Result = await _repositorio.DActualizarAsync(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = "OK";
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<int>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al actualiza el tipo de bien"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(this.BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar el estatus del tipo de bien");
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
                    "Ocurrio un error al actualiza el tipo de bien"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntTipoBienRequest request)
        {
            string nombreMetodo = nameof(this.BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear una tipo de bien");
            try
            {
                BValidarRequest(request);
                var entidad = _mapper.Map<EntTipoBien>(request);
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
                    "Ocurrio un error al intentar crear un tipo de bien"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<EntTipoBienResponse>> BObtenerRegistroAsync(long id)
        {
            string nombreMetodo = nameof(this.BObtenerTodosAsync);
            var resultado = new EntityResponse<EntTipoBienResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tipo de bien");
            try
            {
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                  ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntTipoBienResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {

                resultado = BusExceptionHandler.Handle<EntTipoBienResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar el tipo de bien"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntTipoBienResponse>>> BObtenerTodosAsync(bool? activo)
        {
            string nombreMetodo = nameof(this.BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntTipoBienResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas los tipos de bien");
            try
            {
				Expression<Func<EntTipoBien, bool>>? predicado = activo.HasValue
                    ? r => r.bActivo == activo.Value
                    : null;
                var entidades = await _repositorio.DObtenerTodosAsync(predicado: predicado);
                resultado.Result = _mapper.Map<IEnumerable<EntTipoBienResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntTipoBienResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los tipos de bien"
                );
            }
            return resultado;
        }
    }
}
