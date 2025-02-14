using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteMueble
{
	public class BusTramite : IBusTramite
	{
		private readonly IDatDetalleSolicitud _repositorio;
		private readonly IDatEtapaTramite _repositorioEtapaTramite;
		private readonly ILogger<BusTramite> _logger;
		private readonly EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTramite;
		private readonly EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTramite;

		public  BusTramite(IDatDetalleSolicitud repositorioDetalleSolicitud, IDatEtapaTramite repositorioEtapaTramite, ILogger<BusTramite> logger)
		{
			_repositorio = repositorioDetalleSolicitud;
			_repositorioEtapaTramite = repositorioEtapaTramite;
			_logger = logger;
		}
		

		public async Task<EntityResponse<IEnumerable<EntEtapaResponse>>> BObtenerEtapasPorTramiteAsync(long? idTramite)
		{
			var nombreMetodo = nameof(BObtenerEtapasPorTramiteAsync);
			var resultado = new EntityResponse<IEnumerable<EntEtapaResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar las etapas siguientes del tramite");
			try
			{
				if (idTramite == null || idTramite.Value == 0)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "Se requiere el ID del Tramite");

				var incluir = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.Solicitud
				};

				var detalleSolicitud = await _repositorio.DObtenerRegistroAsync(incluir: incluir, predicado: e => e.iIdDetalleSolicitud == idTramite)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				var etapasSiguientes = await _repositorioEtapaTramite.DObtenerProyeccionListaAsync<EntEtapaResponse>(e => e.iIdEtapaOrigen == detalleSolicitud.iIdEtapa && e.iIdTipoTramite == detalleSolicitud.Solicitud.iIdTipoTramite);

				resultado.Success(etapasSiguientes, _code);

			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntEtapaResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar las etapas siguientes del tramite"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<bool>> BTramitePermiteModificacionAsync(long idTramite)
		{
			var nombreMetodo = nameof(BTramitePermiteModificacionAsync);
			var resultado = new EntityResponse<bool>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para validar si el tramite permite modificaciones");
			try
			{
				var entidad = await _repositorio.DObtenerRegistroAsync(idTramite)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var etapaActualPermiteModificacion = entidad.iIdEtapa == (long)EnumEtapa.CapturaInicial;
				if (!etapaActualPermiteModificacion)
				{
					throw new BusConflictoException("En la etapa actual, el trámite está bloqueada y no permite realizar cambios.");
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
					"Ocurrio un error al intentar valir si el tramire en la etapa actual permite modificaciones"
				);
			}

			return resultado;
		}
	}
}
