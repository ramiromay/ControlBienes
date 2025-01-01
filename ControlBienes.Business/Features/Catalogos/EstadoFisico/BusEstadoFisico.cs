using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.EstadoFisico;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.EstadoFisico
{
    public class BusEstadoFisico : IBusEstadoFisico
    {
        private readonly IDatEstadoFisico _repositorio;
        private readonly ILogger<BusEstadoFisico> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntEstadoFisicoRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkEstadoFisico;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorEstadoFisico;

        public BusEstadoFisico(IDatEstadoFisico repositorio, IMapper mapper, ILogger<BusEstadoFisico> logger,
            IValidator<EntEstadoFisicoRequest> validator)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }
        private void BValidarRequest(EntEstadoFisicoRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntEstadoFisicoRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un estado fisico");
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
                    "Ocurrio un error al intentar actualiza el estado fisico"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del estado fisico");
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
                    "Ocurrio un error al intentar actualizar el estatus del estado fisico"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntEstadoFisicoRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un estado fisico");
            try
            {
                BValidarRequest(request);
                var entidad = _mapper.Map<EntEstadoFisico>(request);
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
                    "Ocurrio un error al intentar crear el estado fisico"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntEstadoFisicoResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntEstadoFisicoResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el estado fisico");
            try
            {
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntEstadoFisicoResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntEstadoFisicoResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar el estado fisico"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntEstadoFisicoResponse>>> BObtenerTodosAsync(bool? activo)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntEstadoFisicoResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los estados fisicos");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync(predicado: e => e.bActivo == activo.Value);
                resultado.Result = _mapper.Map<IEnumerable<EntEstadoFisicoResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntEstadoFisicoResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los estados fisicos"
                );
            }

            return resultado;
        }
    }
}
