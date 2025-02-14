using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.Etapa;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Business.Features.Patrimonio.Solicitud
{
	public class BusSolicitud : IBusSolicitud
	{
		private readonly IDatSolicitud _repositorio;
		private readonly IDatEtapaSolicitud _repositorioEtapaSolicitud;
		private  readonly ILogger<BusSolicitud> _logger;
		private readonly EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkSolicitud;
		private readonly EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorSolicitud;

		public BusSolicitud(IDatSolicitud repositorio, IDatEtapaSolicitud repositorioEtapaSolicitud, ILogger<BusSolicitud> logger)
		{
			_repositorio = repositorio;
			_repositorioEtapaSolicitud = repositorioEtapaSolicitud;
			_logger = logger;
		}

		public async Task<EntityResponse<IEnumerable<EntEtapaResponse>>> BObtenerEtapasPorSolicitudAsync(long? idSolicitud)
		{
			var nombreMetodo = nameof(BObtenerEtapasPorSolicitudAsync);
			var resultado = new EntityResponse<IEnumerable<EntEtapaResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar las etapas siguientes de la solicitud");
			try
			{
				if (idSolicitud == null || idSolicitud.Value == 0)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "Se requiere el ID de la Solicitud");

				var solicitud = await _repositorio.DObtenerRegistroAsync(idSolicitud.Value)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				var etapasSiguientes = await _repositorioEtapaSolicitud.DObtenerProyeccionListaAsync<EntEtapaResponse>(e => e.iIdEtapaOrigen == solicitud.iIdEtapa);

				resultado.Success(etapasSiguientes, _code);

			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntEtapaResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar las etapas siguientes de la solicitud"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<long>> BObtenerIDTipoTramitePorSolicitudAsync(long? idSolicitud)
		{
			var nombreMetodo = nameof(BObtenerIDTipoTramitePorSolicitudAsync);
			var resultado = new EntityResponse<long>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tipo de tramite de la solicitud");
			try
			{
				if (idSolicitud == null || idSolicitud.Value == 0)
					throw new BusRecursoNoEncontradoException("Se requiere el ID de la Solicitud");

				var solicitud = await _repositorio.DObtenerRegistroAsync(idSolicitud.Value);
				resultado.Success(solicitud.iIdTipoTramite, _code);

			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<long>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el tipo de tramite de la solicitud"
				);
			}
			return resultado;
		}

		public async Task<EntityResponse<bool>> BSolicitudPermiteModificacionAsync(long idSolicitud)
		{
			var nombreMetodo = nameof(BSolicitudPermiteModificacionAsync);
			var resultado = new EntityResponse<bool>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para validar si la solicitud permite modificaciones");
			try
			{
				var entidad = await _repositorio.DObtenerRegistroAsync(idSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var etapaActualPermiteModificacion = entidad.iIdEtapa == (long)EnumEtapa.CapturaInicial;
				if (!etapaActualPermiteModificacion)
				{
					throw new BusConflictoException("En la etapa actual, la solicitud está bloqueada y no permite realizar cambios.");
				}
				resultado.Success(etapaActualPermiteModificacion, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<bool>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar valir si la etapa actual de la solicitud permite modificaciones"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<bool>> BSolicitudPermiteNuevosTramitesAsync(long idSolicitud)
		{
			var nombreMetodo = nameof(BSolicitudPermiteNuevosTramitesAsync);
			var resultado = new EntityResponse<bool>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para validar si la solicitud permite nuevos tramites");
			try
			{
				var entidad = await _repositorio.DObtenerRegistroAsync(idSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var solicitudPermiteNuevosTramites = entidad.iIdEtapa == (long)EnumEtapa.Rechazo  ||
					entidad.iIdEtapa == (long)EnumEtapa.VOBO;

				if (!solicitudPermiteNuevosTramites)
				{
					throw new BusConflictoException("En la etapa actual, la solicitud no permite agregar nuevos tramites");
				}
				resultado.Success(solicitudPermiteNuevosTramites, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<bool>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar valir si la solicitud permite nuevos tramites"
				);
			}

			return resultado;
		}
	}
}
