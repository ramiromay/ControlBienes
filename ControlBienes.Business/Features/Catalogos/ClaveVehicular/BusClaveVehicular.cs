using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.ClaveVehicular;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.ClaveVehicular
{
    public class BusClaveVehicular : IBusClaveVehicular
    {
        private readonly IDatClaveVehicular _repositorio;
        private readonly ILogger<BusClaveVehicular> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntClaveVehicularRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkClaveVehicular;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorClaveVehicular;

        public BusClaveVehicular(IDatClaveVehicular repositorio, IMapper mapper, ILogger<BusClaveVehicular> logger,
            IValidator<EntClaveVehicularRequest> validator)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntClaveVehicularRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntClaveVehicularRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar una clave vehicular");
            try
            {
                BValidarRequest(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.sNombre = request.Nombre;
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
                    "Ocurrio un error al intentar actualiza la clave vehicular"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus de la clave vehicular");
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
                    "Ocurrio un error al intentar actualizar el estatus de la clave vehicular"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntClaveVehicularRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear una clave vehicular");
            try
            {
                BValidarRequest(request);
                var entidad = _mapper.Map<EntClaveVehicular>(request);
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
                    "Ocurrio un error al intentar crear la clave vehicular"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntClaveVehicularResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntClaveVehicularResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar la clave vehicular");
            try
            {
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntClaveVehicularResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntClaveVehicularResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar la clave vehicular"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntClaveVehicularResponse>>> BObtenerTodosAsync(bool? activo)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntClaveVehicularResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos las claves vehiculares");
            try
            {
				Expression<Func<EntClaveVehicular, bool>>? predicado = activo.HasValue
                    ? r => r.bActivo == activo.Value
                    : null;
				var entidades = await _repositorio.DObtenerTodosAsync(predicado: predicado);
                resultado.Result = _mapper.Map<IEnumerable<EntClaveVehicularResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntClaveVehicularResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos las claves vehiculares"
                );
            }

            return resultado;
        }
    }
}
