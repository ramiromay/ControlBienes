using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.Subfamilia
{
    public class BusSubfamilia : IBusSubfamilia
    {
        private readonly IDatSubfamilia _repositorio;
        private readonly IDatFamilia _repositorioFamilia;
        private readonly IMapper _mapper;
        private readonly ILogger<BusSubfamilia> _logger;
        private readonly IValidator<EntSubfamiliaRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkSubfamilia;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorSubfamilia;

        public BusSubfamilia(IDatSubfamilia repositorio, IDatFamilia repositorioFamilia, IMapper mapper,
            ILogger<BusSubfamilia> logger, IValidator<EntSubfamiliaRequest> validator)
        {
            _repositorio = repositorio;
            _repositorioFamilia = repositorioFamilia;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntSubfamiliaRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            string errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        private async Task BValidarRequestBD(EntSubfamiliaRequest request, bool esMetodoCreacion)
        {
            var existeFamilia = await _repositorioFamilia.DExisteRegistroAsync(f => f.iIdFamilia == request.IdFamilia);
            var existeIdSubamilia = esMetodoCreacion
                ? await _repositorio.DExisteRegistroAsync(f => f.iIdSubfamilia == request.IdSubfamilia)
                : false;

            string errores = "";
            if (existeIdSubamilia) errores = "El ID de la Subfamilia ya se encuentra registrado,";
            if (!existeFamilia) errores += "La Familia no existe";
            if (string.IsNullOrEmpty(errores)) return;
            errores = BusConvertirErrors.URemoverComillaFinal(errores);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntSubfamiliaRequest request)
        {
            string nombreMetodo = nameof(this.BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar una subfamilia");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request, false);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

                entidad.sNombre = request.Nombre;
                entidad.iIdFamilia = request.IdFamilia;
                entidad.sDescripcion = request.Descripcion;
                entidad.dValorRecuperable = request.ValorRecuperable;
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
                    "Ocurrio un error al intentar actualiza la subfamilia"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(this.BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus de la subfamilia");
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
                    "Ocurrio un error al intentar actualizar la subfamilia"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntSubfamiliaRequest request)
        {
            string nombreMetodo = nameof(this.BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear una subfamilia");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request, true);
                var entidad = _mapper.Map<EntSubfamilia>(request);
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
                    "Ocurrio un error al intentar crear la subfamilia"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<EntSubfamiliaResponse>> BObtenerRegistroAsync(long id)
        {
            string nombreMetodo = nameof(this.BObtenerTodosAsync);
            var resultado = new EntityResponse<EntSubfamiliaResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar la subfamilia");
            try
            {
                var includes = new List<Expression<Func<EntSubfamilia, object>>>()
                {
                    f => f.Familia!
                };
                var entidad = await _repositorio.DObtenerRegistroAsync(e => e.iIdSubfamilia == id, includes)
                  ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntSubfamiliaResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntSubfamiliaResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar la subfamilia"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntSubfamiliaResponse>>> BObtenerTodosAsync()
        {
            string nombreMetodo = nameof(this.BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntSubfamiliaResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las subfamilias");
            try
            {
                var includes = new List<Expression<Func<EntSubfamilia, object>>>()
                {
                    f => f.Familia!
                };
                var entidades = await _repositorio.DObtenerTodosAsync(includes);
                resultado.Result = _mapper.Map<IEnumerable<EntSubfamiliaResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntSubfamiliaResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar las subfamilias"
                );
            }
            return resultado;
        }
    }
}
