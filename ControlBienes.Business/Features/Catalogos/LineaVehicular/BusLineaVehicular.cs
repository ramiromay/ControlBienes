using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.LineaVehicular;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.LineaVehicular
{
    public class BusLineaVehicular : IBusLineaVehicular
    {

        private readonly IDatLineaVehicular _repositorio;
        private readonly IMapper _mapper;
        private readonly ILogger<BusLineaVehicular> _logger;
        private readonly IValidator<EntLineaVehicularRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkLineaVehicular;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorLineaVehicular;

        public BusLineaVehicular(IDatLineaVehicular repository, IMapper mapper, ILogger<BusLineaVehicular> logger, IValidator<EntLineaVehicularRequest> validator)
        {
            _repositorio = repository;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntLineaVehicularRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (!resultadoValidacion.IsValid)
            {
                string errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
                throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
            }
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntLineaVehicularRequest request)
        {
            string nombreMetodo = nameof(this.BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar la linea vehicular");
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
                    "Ocurrio un error al actualiza la linea vehicular"
                );

            }
            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(this.BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogError($"{(long)_code}: Inicia la operacion para actualizar el estatus de la liena vehicular");
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
                    "Ocurrio un error al intentar actualizar la linea vehicular"
                );

            }
            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntLineaVehicularRequest request)
        {
            string nombreMetodo = nameof(this.BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear una linea vehicular");
            try
            {
                BValidarRequest(request);
                var entidad = _mapper.Map<EntLineaVehicular>(request);
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
                    "Ocurrio un error al intentar crear la linea vehicular"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<EntLineaVehicularResponse>> BObtenerRegistroAsync(long id)
        {
            string nombreMetodo = nameof(this.BObtenerTodosAsync);
            var resultado = new EntityResponse<EntLineaVehicularResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar la linea vehicular");
            try
            {
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                   ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntLineaVehicularResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntLineaVehicularResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar la linea vehicular"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntLineaVehicularResponse>>> BObtenerTodosAsync()
        {
            string nombreMetodo = nameof(this.BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntLineaVehicularResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las lineas vehiculares");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync();
                resultado.Result = _mapper.Map<IEnumerable<EntLineaVehicularResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntLineaVehicularResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio  un error al intentar consultar todas las lineas vehiculares"
                );
            }
            return resultado;
        }
    }
}
