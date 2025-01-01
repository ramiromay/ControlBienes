using AutoMapper;
using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.Familia;
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

namespace ControlBienes.Business.Features.Catalogos.CentroTrabajoTurno
{
    public class BusCentroTrabajoTurno : IBusCentroTrabajoTurno
    {
        private readonly IDatCentroTrabajoTurno _repositorio;
        private readonly IDatCentroTrabajo _repositorioCentroTrabajo;
        private readonly IDatTurno _repositorioTurno;
        private readonly ILogger<BusCentroTrabajoTurno> _logger;
        private readonly IMapper _mapper;
        private readonly IValidator<EntCentroTrabajoTurnoRequest> _validator;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkCentroTrabajoTurno;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorCentroTrabajoTurno;

        public BusCentroTrabajoTurno(IDatCentroTrabajoTurno repositorio, IDatCentroTrabajo repositorioCentroTrabajo, 
            IDatTurno repositorioTurno, IMapper mapper, ILogger<BusCentroTrabajoTurno> logger,
            IValidator<EntCentroTrabajoTurnoRequest> validator)
        {
            _repositorio = repositorio;
            _repositorioCentroTrabajo = repositorioCentroTrabajo;
            _repositorioTurno = repositorioTurno;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        private void BValidarRequest(EntCentroTrabajoTurnoRequest request)
        {
            var resultadoValidacion = _validator.Validate(request);
            if (resultadoValidacion.IsValid) return;
            var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        private async Task BValidarRequestBD(EntCentroTrabajoTurnoRequest request)
        {
            var existeCentroTrabajo = await _repositorioCentroTrabajo.DExisteRegistroAsync(e => e.iIdCentroTrabajo == request.IdCentroTrabajo);
            var existeTurno = await _repositorioTurno.DExisteRegistroAsync(e => e.iIdTurno == request.IdTurno);

            string errores = "";
            if (!existeCentroTrabajo) errores += "El Centro de Trabajo no se encuentra registrado";
            if (!existeTurno) errores += "El Turno no se encuentra registrado";
            if (string.IsNullOrEmpty(errores)) return;
            errores = BusConvertirErrors.URemoverComillaFinal(errores);
            throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
        }

        public async Task<EntityResponse<int>> BActualizarAsync(long id, EntCentroTrabajoTurnoRequest request)
        {
            string nombreMetodo = nameof(BActualizarAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un turno del centro de trabajo");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request);
                var entidad = await _repositorio.DObtenerRegistroAsync(id)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                entidad.iIdCentroTrabajo = request.IdCentroTrabajo.Value;
                entidad.iIdTurno = request.IdTurno.Value;
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
                    "Ocurrio un error al intentar actualiza el turno del centro de trabajo"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
        {
            string nombreMetodo = nameof(BCambiarEstatusAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del turno del centro de trabajo");
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
                    "Ocurrio un error al intentar actualizar el estatus del turno del centro de trabajo"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<int>> BCrearAsync(EntCentroTrabajoTurnoRequest request)
        {
            var nombreMetodo = nameof(BCrearAsync);
            var resultado = new EntityResponse<int>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un turno del centro de trabajo");
            try
            {
                BValidarRequest(request);
                await BValidarRequestBD(request);
                var entidad = _mapper.Map<EntCentroTrabajoTurno>(request);
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
                    "Ocurrio un error al intentar crear el turno del centro de trabajo"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<EntCentroTrabajoTurnoResponse>> BObtenerRegistroAsync(long id)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<EntCentroTrabajoTurnoResponse>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el turno del centro de trabajo");
            try
            {
                var includes = new List<Expression<Func<EntCentroTrabajoTurno, object>>>()
                {
                    f => f.CentroTrabajo,
                    f => f.Turno
                };
                var entidad = await _repositorio.DObtenerRegistroAsync(e => e.iIdCentroTrabajoTurno == id, includes)
                    ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
                resultado.Result = _mapper.Map<EntCentroTrabajoTurnoResponse>(entidad);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<EntCentroTrabajoTurnoResponse>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar el turno del centro de trabajo"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntCentroTrabajoTurnoResponse>>> BObtenerTodosAsync(bool? activo)
        {
            var nombreMetodo = nameof(BObtenerTodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntCentroTrabajoTurnoResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los turnos de los centro de trabajo");
            try
            {
                var includes = new List<Expression<Func<EntCentroTrabajoTurno, object>>>()
                {
                    f => f.CentroTrabajo,
                    f => f.Turno
                };
				var entidades = await _repositorio.DObtenerTodosAsync(
					incluir: includes,
					predicado: e => e.bActivo == activo.Value);
				resultado.Result = _mapper.Map<IEnumerable<EntCentroTrabajoTurnoResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntCentroTrabajoTurnoResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los turnos de los centro de trabajo"
                );
            }

            return resultado;
        }
    }
}
