using AutoMapper;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Patrimonio.SolicitudVehiculo;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.SolicitudInmueble
{
	public class BusSolicitudInmueble : IBusSolicitudInmueble
	{
		private readonly IDatSolicitud _repositorio;
		private readonly IDatEmpleado _repositorioEmpleado;
		private readonly IDatTipoTramite _repositorioTipoTramite;
		private readonly IDatMotivoTramite _repositorioMotivoTramite;
		private readonly IDatPeriodo _repositorioPeriodo;
		private readonly IDatUnidadAdministrativa _repositorioUnidadAdministrativa;
		private readonly IDatEtapaTramite _repositorioEtapaTramite;
		private readonly IDatEtapaSolicitud _repositorioEtapaSolicitud;
		private readonly IMapper _mapper;
		private readonly ILogger<BusSolicitudInmueble> _logger;
		private readonly IValidator<EntSolicitudInmuebleRequest> _validator;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkSolicitudMueble;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorSolicitudMueble;

		public BusSolicitudInmueble(IDatSolicitud repositorio, IDatEmpleado repositorioEmpleado, IDatTipoTramite repositorioTipoTramite, IDatMotivoTramite repositorioMotivoTramite, IDatPeriodo repositorioPeriodo, IDatUnidadAdministrativa repositorioUnidadAdministrativa, IDatEtapaTramite repositorioEtapaTramite, IDatEtapaSolicitud repositorioEtapaSolicitud, IMapper mapper, ILogger<BusSolicitudInmueble> logger, IValidator<EntSolicitudInmuebleRequest> validator)
		{
			_repositorio = repositorio;
			_repositorioEmpleado = repositorioEmpleado;
			_repositorioTipoTramite = repositorioTipoTramite;
			_repositorioMotivoTramite = repositorioMotivoTramite;
			_repositorioPeriodo = repositorioPeriodo;
			_repositorioUnidadAdministrativa = repositorioUnidadAdministrativa;
			_repositorioEtapaTramite = repositorioEtapaTramite;
			_repositorioEtapaSolicitud = repositorioEtapaSolicitud;
			_mapper = mapper;
			_logger = logger;
			_validator = validator;
		}

		private void BValidarRequest(EntSolicitudInmuebleRequest request)
		{
			var errores = new StringBuilder(string.Empty);
			var resultadoValidacion = _validator.Validate(request);
			if (resultadoValidacion.IsValid && string.IsNullOrEmpty(errores.ToString())) return;
			errores.Append(BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());
		}

		private async Task BValidarRequestBD(EntSolicitudInmuebleRequest request)
		{
			var motivoTramite = await _repositorioMotivoTramite.DObtenerRegistroAsync(request.IdMotivoTramite);
			var unidadAdministrativa = await _repositorioUnidadAdministrativa.DObtenerRegistroAsync(e =>
				e.sNivelCompleto.Equals(request.NivelUnidadAdministrativa));
			var existeEmpleado = await _repositorioEmpleado.DExisteRegistroAsync(e => e.iIdEmpleado == request.IdEmpleado);
			var existeTipoTramite = await _repositorioTipoTramite.DExisteRegistroAsync(e => e.iIdTipoTramite == request.IdTipoTramite);
			var existeUnidadAdministrativa = unidadAdministrativa != null;
			var existeMotivoTramite = motivoTramite != null;
			var unidadAdminATercerNivel = unidadAdministrativa.sNivelCompleto.Split(".").Length == 3;

			var errores = new StringBuilder(string.Empty);
			if (!existeEmpleado) errores.Append("El Empleado no se encuentra registrado,");
			if (!existeUnidadAdministrativa) errores.Append("La Unidad Administrativa no se encuentra registrada,");
			if (existeUnidadAdministrativa && !unidadAdminATercerNivel) errores.Append("La Unidad Administrativa debe estar a 3er Nivel,");
			if (!existeTipoTramite) errores.Append("El Tipo de Tramite no se encuentra registrado,");
			if (!existeMotivoTramite) errores.Append("El Motivo de Tramite no se encuentra registrado,");
			if (existeTipoTramite && existeMotivoTramite && motivoTramite.iIdTipoTramite != request.IdTipoTramite)
				errores.Append("El Motivo de Tramite no corresponde al Tipo de Tramite");

			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter)) return;
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());
		}

		private async Task BValidarParametrosConsulta(
			long? periodo,
			bool busquedaPorFechaActivada,
			DateTime? fechaInicio,
			DateTime? fechaFin,
			string unidadAdministrativa)
		{

			if (!periodo.HasValue)
				throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "Se requiere el Periodo");

			if (busquedaPorFechaActivada)
			{
				if (!fechaInicio.HasValue || !fechaFin.HasValue)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "Se requiere la Fecha de Inicio y de Fin");

				if (fechaInicio.Value.Date > fechaFin.Value.Date)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "La Fecha de Inicio no puede ser mayor a la Fecha de Fin");
			}

			if (string.IsNullOrEmpty(unidadAdministrativa))
				throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "Se requiere la Unidad Administrativa");

			if (!Regex.IsMatch(unidadAdministrativa, EntConstant.UnidadAdministrativaRegex))
				throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "La Unidad Administrativa no es valida");

			var existePeriodo = await _repositorioPeriodo.DExisteRegistroAsync(e => e.iIdPeriodo == periodo);

			if (!existePeriodo)
				throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "El Periodo no se encuentra registrado");

			if (!unidadAdministrativa.Equals(EntConstant.ValorRaiz))
			{
				var existeUnidadAdministrativa = await _repositorioUnidadAdministrativa.DExisteRegistroAsync(e => e.sNivelCompleto == unidadAdministrativa);

				if (!existeUnidadAdministrativa)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "La Unidad Administrativa no se encuentra registrada");
			}
		}

		public async Task<EntityResponse<int>> BActualizarSolicitudAsync(long idSolicitud, EntSolicitudInmuebleRequest request)
		{
			string nombreMetodo = nameof(BActualizarSolicitudAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar una solicitud");
			try
			{
				var entidad = await _repositorio.DObtenerRegistroAsync(idSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				if (entidad.iIdEtapa != (long)EnumEtapa.CapturaInicial)
					throw new BusConflictoException("La solicitud de bienes muebles no permite modificaciones en el etapa actual.");

				BValidarRequest(request);
				await BValidarRequestBD(request);

				var periodo = await _repositorioPeriodo.DObtenerRegistroAsync(e => e.bActivo);
				var unidadAdministrativa = await _repositorioUnidadAdministrativa.DObtenerRegistroAsync(e =>
					e.sNivelCompleto.Equals(request.NivelUnidadAdministrativa));

				entidad.iIdEmpleado = request.IdEmpleado;
				entidad.iIdTipoTramite = request.IdTipoTramite;
				entidad.iIdMotivoTramite = request.IdMotivoTramite;
				entidad.sObservaciones = request.Observaciones;
				entidad.sDocumentoReferencia = request.DocumentoReferencia;
				entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
				entidad.iIdPeriodo = periodo.iIdPeriodo;

				var result = await _repositorio.DActualizarAsync(entidad);
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualiza la solicitud"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCambiarEtapaSolicitudAsync(long idSolicitud, long? idEtapa)
		{
			var nombreMetodo = nameof(BCambiarEtapaSolicitudAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear una solicitud");
			try
			{
				if (!idEtapa.HasValue)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "La Etapa a la que quiere cambiar es requerida");

				var entidad = await _repositorio.DObtenerRegistroAsync(idSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var etapaSiguienteCorrecta = await _repositorioEtapaSolicitud.DValidarCambioEtapaAsync(entidad, idEtapa.Value);

				if (!etapaSiguienteCorrecta)
					throw new BusConflictoException("No se permite avanzar a esta etapa desde la etapa actual");

				var result = await _repositorio.DCambiarEtapaAsync(entidad, idEtapa.Value);
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear la solicitud"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCrearSolicitudAsync(EntSolicitudInmuebleRequest request)
		{
			var nombreMetodo = nameof(BCrearSolicitudAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear una solicitud");
			try
			{
				BValidarRequest(request);
				await BValidarRequestBD(request);
				var periodo = await _repositorioPeriodo.DObtenerRegistroAsync(e => e.bActivo);
				var unidadAdministrativa = await _repositorioUnidadAdministrativa.DObtenerRegistroAsync(e =>
					e.sNivelCompleto.Equals(request.NivelUnidadAdministrativa));
				var entidad = _mapper.Map<EntSolicitudInmuebleRequest, EntSolicitud>(request);
				entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
				entidad.iIdPeriodo = periodo.iIdPeriodo;


				var result = await _repositorio.DCrearAsync(entidad);
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear la solicitud"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntSolicitudInmuebleResponse>> BObtenerSolicitudAsync(long idSolicitud)
		{
			var nombreMetodo = nameof(BObtenerSolicitudAsync);
			var resultado = new EntityResponse<EntSolicitudInmuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar la solicitud");
			try
			{
				var entidad = await _repositorio.DObtenerRegistroAsync(e =>
					e.iIdSolicitud == idSolicitud && e.iIdTipoBien == (long)EnumTipoBien.Inmueble)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				Expression<Func<EntSolicitud, bool>> filtro = e => e.iIdSolicitud == idSolicitud;
				var resultDto = await _repositorio.DObtenerProyeccionElementoAsync<EntSolicitudInmuebleResponse>(predicado: filtro);
				resultado.Success(resultDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntSolicitudInmuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar la solicitud"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntSolicitudInmuebleResponse>>> BObtenerSolicitudesPorFiltroAsync(long? periodo, bool? busquedaPorFecha, DateTime? fechaInicio, DateTime? fechaFin, string unidadAdministrativa)
		{
			var nombreMetodo = nameof(BObtenerSolicitudesPorFiltroAsync);
			var resultado = new EntityResponse<IEnumerable<EntSolicitudInmuebleResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las solicitudes");
			try
			{
				bool busquedaPorFechaActivada = busquedaPorFecha.HasValue && busquedaPorFecha.Value;
				await BValidarParametrosConsulta(periodo, busquedaPorFechaActivada,
					fechaInicio, fechaFin, unidadAdministrativa);

				Expression<Func<EntSolicitud, bool>> filtro = e =>
					e.iIdTipoBien == (long)EnumTipoBien.Inmueble &&
					e.iIdPeriodo == periodo &&
					(unidadAdministrativa.Equals(EntConstant.ValorRaiz) ||
						e.UnidadAdministrativa.sNivelCompleto.Contains(unidadAdministrativa)) &&
					(!busquedaPorFechaActivada ||
						e.dtFechaCreacion.Date >= fechaInicio.Value.Date &&
						e.dtFechaCreacion.Date <= fechaFin.Value.Date);

				var resultListDto = await _repositorio.DObtenerProyeccionListaAsync<EntSolicitudInmuebleResponse>(filtro);
				resultado.Success(resultListDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntSolicitudInmuebleResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todas las solicitudes"
				);
			}

			return resultado;
		}
	}
}
