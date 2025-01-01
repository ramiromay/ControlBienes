using AutoMapper;
using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.Documento;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.Documento
{
    public class BusDocumento : IBusDocumento
    {
        private readonly IDatDocumento _repositorio;
        private readonly ILogger<BusDocumento> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntDocumentoRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkDocumento;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorDocumento;

        public BusDocumento(IDatDocumento repositorio, IMapper mapper, ILogger<BusDocumento> logger,
            IValidator<EntDocumentoRequest> validator)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntDocumentoRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }
        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntDocumentoRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un documento");
            try
            {
                BValidarRequest(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.sNombre = request.Nombre;
                entidad.sAbreviacion = request.Abreviacion;
                entidad.iIdSubModulo = request.IdSubModulo.Value;
                entidad.iIdMotivoTramite = request.IdMotivoTramite.Value;
                entidad.iIdTipoTramite = request.IdTipoTramite.Value;
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
                    "Ocurrio un error al intentar actualiza el documento"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del documento");
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
                    "Ocurrio un error al intentar actualizar el estatus del documento"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntDocumentoRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un documento");
            try
            {
                BValidarRequest(request);
                var entidad = _mapper.Map<EntDocumento>(request);
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
                    "Ocurrio un error al intentar crear el documento"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntDocumentoResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntDocumentoResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el documento");
            try
            {
                var includes = new List<Expression<Func<EntDocumento, object>>>()
                {
                    e => e.MotivoTramite!,
                    e => e.TipoTramite!,
                    e => e.SubModulo!
                };
                var entidad = await _repositorio.DObtenerRegistroAsync(e => e.iIdDocumento == id, includes)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntDocumentoResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntDocumentoResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar el documento"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntDocumentoResponse>>> BObtenerTodosAsync(bool? activo)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntDocumentoResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los documentos");
            try
            {
				Expression<Func<EntDocumento, bool>>? predicado = activo.HasValue
                    ? r => r.bActivo == activo.Value
                    : null;
				var includes = new List<Expression<Func<EntDocumento, object>>>()
                {
                    e => e.MotivoTramite!,
                    e => e.TipoTramite!,
                    e => e.SubModulo!
                };
                var entidades = await _repositorio.DObtenerTodosAsync(incluir: includes, predicado: predicado);
                resultado.Result = _mapper.Map<IEnumerable<EntDocumentoResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntDocumentoResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los documentos"
                );
            }

            return resultado;
        }
    }
}
