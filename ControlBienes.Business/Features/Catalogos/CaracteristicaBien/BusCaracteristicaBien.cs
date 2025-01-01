using AutoMapper;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.CaracteristicaBien
{
    public class BusCaracteristicaBien : IBusCaracteristicaBien
    {
        private readonly IDatCaracteristicaBien _repositorio;
        private readonly IDatFamilia _repositorioFamilia;
        private readonly IDatSubfamilia _repositorioSubfamilia;
        private readonly ILogger<BusCaracteristicaBien> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntCaracteristicaBienRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkCaracteristicaBien;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorCaracteristicaBien;

        public BusCaracteristicaBien(IDatCaracteristicaBien repositorio, IDatFamilia repositorioFamilia, IDatSubfamilia repositorioSubfamilia,
            IMapper mapper, ILogger<BusCaracteristicaBien> logger,
            IValidator<EntCaracteristicaBienRequest> validator)
        {
            _repositorio = repositorio;
            _repositorioFamilia = repositorioFamilia;
            _repositorioSubfamilia = repositorioSubfamilia;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntCaracteristicaBienRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        private async Task BValidarRequestBD(EntCaracteristicaBienRequest request)
        {
            var existeFamilia = await _repositorioFamilia.DExisteRegistroAsync(f => f.iIdFamilia == request.IdFamilia);
            var entidadSubfamilia = await _repositorioSubfamilia.DObtenerRegistroAsync(e => e.iIdSubfamilia == request.IdSubfamilia);
            var existeSubfamilia = entidadSubfamilia != null;

            string errores = "";
            if (!existeFamilia) errores = "La Familia no se encuentra registrada,";
            if (!existeSubfamilia) errores += "La Sub Familia no se encuentra registrada";
            if (existeFamilia && existeSubfamilia && entidadSubfamilia!.iIdFamilia != request.IdFamilia) errores += "La Subfamilia no pertenece a la Familia seleccionada";
            if (string.IsNullOrEmpty(errores)) return;
            errores = BusConvertirErrors.URemoverComillaFinal(errores);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntCaracteristicaBienRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar una caracterisca");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.iIdFamilia = request.IdFamilia.Value;
                entidad.iIdSubfamilia = request.IdSubfamilia.Value  ;
                entidad.sEtiqueta = request.Etiqueta;
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
                    "Ocurrio un error al intentar actualiza la caracteristica"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus de la caracteristica");
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
                    "Ocurrio un error al intentar actualizar el estatus de la caracteristica"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntCaracteristicaBienRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear una carcteristica");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request);
                var entidad = _mapper.Map<EntCaracteristicaBien>(request);
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
                    "Ocurrio un error al intentar crear la caracteristica"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntCaracteristicaBienResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntCaracteristicaBienResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar la caracteristica");
            try
            {
                var includes = new List<Expression<Func<EntCaracteristicaBien, object>>>()
                {
                    cb => cb.Familia!,
                    cb => cb.Subfamilia!
                };
                var entidad = await _repositorio.DObtenerRegistroAsync(cb => cb.iIdCaracteristicaBien == id, includes)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntCaracteristicaBienResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntCaracteristicaBienResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar la caracteristica"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntCaracteristicaBienResponse>>> BObtenerTodosAsync(bool? activos)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntCaracteristicaBienResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las caracteristicas");
            try
            {
                var includes = new List<Expression<Func<EntCaracteristicaBien, object>>>()
                {
                    cb => cb.Familia!,
                    cb => cb.Subfamilia!
                };
                var entidades = await _repositorio.DObtenerTodosAsync(
                    incluir: includes, 
                    predicado: cb => cb.bActivo == activos.Value);

                var responseDto = _mapper.Map<IEnumerable<EntCaracteristicaBienResponse>>(entidades);
                resultado.Success(responseDto, _code);
			}
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntCaracteristicaBienResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todas las caracteristicas"
                );
            }

            return resultado;
        }
    }
}
