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
using System;
using System.Linq.Expressions;
using System.Net;

namespace ControlBienes.Business.Features.Catalogos.Familia
{
    public class BusFamilia : IBusFamilia
    {

        private readonly IDatFamilia _repositorio;
        private readonly IDatTipoBien _repositorioTipoBien;
        private readonly IMapper _mapper;
        private readonly ILogger<BusFamilia> _logger;
        private readonly IValidator<EntFamiliaRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkFamilia;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorFamilia;

        public BusFamilia(IDatFamilia repositorio, IMapper mapper, ILogger<BusFamilia> logger,
            IValidator<EntFamiliaRequest> validator, IDatTipoBien repositorioTipoBien)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
            _repositorioTipoBien = repositorioTipoBien;
        }

        private void BValidarRequest(EntFamiliaRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            string errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        private async Task BValidarRequestBD(EntFamiliaRequest request, bool esMetodoCreacion)
        {
            //var existeTipoBienTask = _repositorioTipoBien.DExisteRegistroAsync(tp => tp.iIdTipoBien == request.IdTipoBien);
            //var existeIdFamiliaTask = esMetodoCreacion
            //    ? _repositorio.DExisteRegistroAsync(f => f.iIdFamilia == request.IdFamilia)
            //    : Task.FromResult(false);

            //await Task.WhenAll(existeTipoBienTask, existeIdFamiliaTask);

            var existeTipoBien = await _repositorioTipoBien.DExisteRegistroAsync(tp => tp.iIdTipoBien == request.IdTipoBien);
            var existeIdFamilia = esMetodoCreacion
                ? await _repositorio.DExisteRegistroAsync(f => f.iIdFamilia == request.IdFamilia)
                : false;

            string errores = "";
            if (existeIdFamilia) errores = "El ID de la Familia ya se encuentra registrado,";
            if (!existeTipoBien) errores += "El Tipo de Bien no existe";
            if (string.IsNullOrEmpty(errores)) return;
            errores = BusConvertirErrors.URemoverComillaFinal(errores);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntFamiliaRequest request)
        {
            string nombreMetodo = nameof(this.BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar una familia");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request, false);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.sNombre = request.Nombre;
                entidad.sDescripcion = request.Descripcion;
                entidad.iIdTipoBien = request.IdTipoBien;
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
                    "Ocurrio un error al intentar actualiza la familia"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(this.BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus de la familia");
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
                    "Ocurrio un error al intentar actualizar la familia"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntFamiliaRequest request)
        {
            string nombreMetodo = nameof(this.BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear una familia");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request, true);
                var entidad = _mapper.Map<EntFamilia>(request);
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
                    "Ocurrio un error al intentar crear la familia"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<EntFamiliaResponse>> BObtenerRegistroAsync(long id)
        {
            string nombreMetodo = nameof(this.BObtenerTodosAsync);
            var resultado = new EntityResponse<EntFamiliaResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar la familia");
            try
            {
                var includes = new List<Expression<Func<EntFamilia, object>>>()
                {
                    f => f.TipoBien!
                };
                var entidad = await _repositorio.DObtenerRegistroAsync(e => e.iIdFamilia == id, includes)
                  ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntFamiliaResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntFamiliaResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar la familia"
                );
            }
            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntFamiliaResponse>>> BObtenerTodosAsync(bool? activo)
        {
            string nombreMetodo = nameof(this.BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntFamiliaResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las familias");
			try
            {
				Expression<Func<EntFamilia, bool>>? predicado = activo.HasValue
                    ? r => r.bActivo == activo.Value
                    : null;
				var includes = new List<Expression<Func<EntFamilia, object>>>()
                {
                    f => f.TipoBien!
                };
                var entidades = await _repositorio.DObtenerTodosAsync(incluir: includes, predicado: predicado);
                resultado.Result = _mapper.Map<IEnumerable<EntFamiliaResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntFamiliaResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar las familias"
                );
            }
            return resultado;
        }
    }
}
