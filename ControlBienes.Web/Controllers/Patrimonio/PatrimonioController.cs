using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class PatrimonioController : ControllerBase
	{
		private readonly IBusTramite _servicioTramite;
		private readonly IBusSolicitud _servicioSolicitud;
		private readonly IBusInventario _servicioInventario;
		private readonly IBusTipoDominio _servicioTipoDominio;
		private readonly IBusClasificacionConac _servicioClasificacionConacyt;

		public PatrimonioController(IBusTramite servicioSolicitudTramite, IBusSolicitud servicioSolicitud, IBusInventario servicioInventario, IBusTipoDominio servicioTipoDominio, IBusClasificacionConac servicioClasificacionConacyt)
		{
			_servicioTramite = servicioSolicitudTramite;
			_servicioSolicitud = servicioSolicitud;
			_servicioInventario = servicioInventario;
			_servicioTipoDominio = servicioTipoDominio;
			_servicioClasificacionConacyt = servicioClasificacionConacyt;
		}


		[HttpGet("TipoDominio")]
		[AutorizacionSICBA]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntEtapaResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntEtapaResponse>>>> CObtenerTiposDominioAsync()
		{
			var response = await _servicioTipoDominio.BObtenerTiposDominioAsync();
			return StatusCode((int)response.StatusCode, response);
		}


		[HttpGet("ClasificacionConac")]
		[AutorizacionSICBA]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntEtapaResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntEtapaResponse>>>> CObtenerClasificacionConacAsync()
		{
			var response = await _servicioClasificacionConacyt.ObtenerClasificacionConacAsync();
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Articulo/{idTipoBien}")]
		[AutorizacionSICBA]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntEtapaResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntArticuloBienResponse>>>> CObtenerClasificacionConacAsync(long idTipoBien)
		{
			var response = await _servicioInventario.BObtenerArbolTiposBienesAsync(idTipoBien);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Tramite/{idTramite}/Etapas")]
		[AutorizacionSICBA]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntEtapaResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntEtapaResponse>>>> CObtenerEtapasPorTramiteAsync(long? idTramite)
		{
			var response = await _servicioTramite.BObtenerEtapasPorTramiteAsync(idTramite);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Tramite/{idSolicitud}/PermiteModificacion")]
		[AutorizacionSICBA]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CTramitePermiteModificacionAsync(long idSolicitud)
		{
			var response = await _servicioTramite.BTramitePermiteModificacionAsync(idSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Solicitud/{idSolicitud}/Etapas")]
		[AutorizacionSICBA]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntEtapaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntEtapaResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntEtapaResponse>>>> CObtenerEtapasPorSolicitudAsync(long? idSolicitud)
		{
			var response = await _servicioSolicitud.BObtenerEtapasPorSolicitudAsync(idSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Solicitud/{idSolicitud}/TipoTramite")]
		[AutorizacionSICBA]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<long>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<long>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<long>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<long>))]
		public async Task<ActionResult<EntityResponse<long>>> CObtenerTipoTramitePorSolicitudAsync(long? idSolicitud)
		{
			var response = await _servicioSolicitud.BObtenerIDTipoTramitePorSolicitudAsync(idSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Solicitud/{idSolicitud}/PermiteModificacion")]
		[AutorizacionSICBA]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CSolicitudPermiteModificacionAsync(long idSolicitud)
		{
			var response = await _servicioSolicitud.BSolicitudPermiteModificacionAsync(idSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Solicitud/{idSolicitud}/PermiteNuevoTramite")]
		[AutorizacionSICBA]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CSolicitudPermiteNuevoTramiteAsync(long idSolicitud)
		{
			var response = await _servicioSolicitud.BSolicitudPermiteNuevosTramitesAsync(idSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Inventario/Bien")]
		[AutorizacionSICBA]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntBienPatrimonioResponse>>>> CObtenerBienesAsync([FromQuery]long? tipoBien, long? detalleSolicitud)
		{
			var response = await _servicioInventario.BObtenerBienesInventarioAsync(tipoBien, detalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

	}
}
