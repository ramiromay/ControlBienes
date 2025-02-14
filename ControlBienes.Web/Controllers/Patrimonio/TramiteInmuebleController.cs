using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/Patrimonio/[controller]")]
	public class TramiteInmuebleController : Controller
	{
		private readonly IBusTramiteInmueble _servicioTramiteMueble;

		public TramiteInmuebleController(IBusTramiteInmueble servicioTramiteMueble)
		{
			_servicioTramiteMueble = servicioTramiteMueble;
		}


		[HttpPatch("{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesInmuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCambiarEtapaTramiteAsync(long idDetalleSolicitud, [FromQuery] long? etapa)
		{
			var response = await _servicioTramiteMueble.BCambiarEtapaTramiteAsync(idDetalleSolicitud, etapa);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("Alta")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesInmuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteAlta([FromBody] EntDetalleAltaInmuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BCrearTramiteAltaAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Alta/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesInmuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteAlta(long idDetalleSolicitud, [FromBody] EntDetalleAltaInmuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BActualizarTramiteAltaAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Alta/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesInmuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleAltaMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleAltaMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleAltaMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleAltaMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleAltaMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleAltaMuebleResponse>>> CObtenerTramiteAlta(long idDetalleSolicitud)
		{
			var response = await _servicioTramiteMueble.BObtenerTramiteAltaAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}


		[HttpPost("Modificacion")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesInmuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteModificacion([FromBody] EntDetalleModificacionInmuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BCrearTramiteModificacionAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Modificacion/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesInmuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteModificacion(long idDetalleSolicitud, [FromBody] EntDetalleModificacionInmuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BActualizarTramiteModificacionAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Modificacion/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesInmuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleModificacionInmuebleResponse>>> CObtenerTramiteModificacion(long idDetalleSolicitud)
		{
			var response = await _servicioTramiteMueble.BObtenerTramiteModificacionAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("Baja")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesInmuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteBajaAsync([FromBody] EntDetalleBajaInmuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BCrearTramiteBajaAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Baja/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesInmuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteModificacion(long idDetalleSolicitud, [FromBody] EntDetalleBajaInmuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BActualizarTramiteBajaAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Baja/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesInmuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleBajaInmuebleResponse>>> CObtenerTramiteBajaAsync(long idDetalleSolicitud)
		{
			var response = await _servicioTramiteMueble.BObtenerTramiteBajaAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

	}
}
