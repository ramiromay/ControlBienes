using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleDesincorporacion;
using ControlBienes.Entities.Patrimonio.DetalleDestinoFinal;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleMovimiento;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/Patrimonio/[controller]")]
	public class TramiteMuebleController : ControllerBase
	{
		private readonly IBusTramiteMueble _servicioTramiteMueble;

		public TramiteMuebleController(IBusTramiteMueble servicioTramiteMueble)
		{
			_servicioTramiteMueble = servicioTramiteMueble;
		}

		[HttpPatch("{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
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

		[HttpGet("Seguimiento/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<IEnumerable<EntSeguimientoResponse>>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<IEnumerable<EntSeguimientoResponse>>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<IEnumerable<EntSeguimientoResponse>>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<IEnumerable<EntSeguimientoResponse>>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<IEnumerable<EntSeguimientoResponse>>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntSeguimientoResponse>>>> CSeguimientoTramiteAsync(long idDetalleSolicitud)
		{
			var response = await _servicioTramiteMueble.BObtenerSeguimientoTramiteAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("{idSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>>> CObtenerTramitesPorSolicitudAsync(long idSolicitud)
		{
			var response = await _servicioTramiteMueble.BObtenerTramitesPorSolicitudAsync(idSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("Alta")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteAlta([FromBody] EntDetalleAltaMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BCrearTramiteAltaAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Alta/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteAlta(long idDetalleSolicitud, [FromBody] EntDetalleAltaMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BActualizarTramiteAltaAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Alta/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
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
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteModificacion([FromBody] EntDetalleModificacionMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BCrearTramiteModificacionAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Modificacion/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteModificacion(long idDetalleSolicitud, [FromBody] EntDetalleModificacionMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BActualizarTramiteModificacionAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Modificacion/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleModificacionMuebleResponse>>> CObtenerTramiteModificacion(long idDetalleSolicitud)
		{
			var response = await _servicioTramiteMueble.BObtenerTramiteModificacionAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}


		[HttpPost("Baja")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteBajaAsync([FromBody] EntDetalleBajaMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BCrearTramiteBajaAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Baja/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteModificacion(long idDetalleSolicitud, [FromBody] EntDetalleBajaMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BActualizarTramiteBajaAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Baja/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleBajaMuebleResponse>>> CObtenerTramiteBajaAsync(long idDetalleSolicitud)
		{
			var response = await _servicioTramiteMueble.BObtenerTramiteBajaAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("Movimiento")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteMovimientoAsync([FromBody] EntDetalleMovimientoMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BCrearTramiteMovimientoAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Movimiento/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteMovimiento(long idDetalleSolicitud, [FromBody] EntDetalleMovimientoMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BActualizarTramiteMovimientoAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Movimiento/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleBajaMuebleResponse>>> CObtenerTramiteMovimientoAsync(long idDetalleSolicitud)
		{
			var response = await _servicioTramiteMueble.BObtenerTramiteMovimientoAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("Desincorporacion")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteDesincorporacionAsync([FromBody] EntDetalleDesincorporacionMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BCrearTramiteDesincorporacionAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Desincorporacion/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteDesincorporacion(long idDetalleSolicitud, [FromBody] EntDetalleDesincorporacionMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BActualizarTramiteDesincorporacionAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Desincorporacion/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleDesincorporacionMuebleResponse>>> CObtenerTramiteDesincorporacionAsync(long idDetalleSolicitud)
		{
			var response = await _servicioTramiteMueble.BObtenerTramiteDesincorporacionAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("DestinoFinal")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteDestinoFinalnAsync([FromBody] EntDetalleDestinoFinalMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BCrearTramiteDestinoFinalAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("DestinoFinal/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteDestinoFinal(long idDetalleSolicitud, [FromBody] EntDetalleDestinoFinalMuebleRequest request)
		{
			var response = await _servicioTramiteMueble.BActualizarTramiteDestinoFinalAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("DestinoFinal/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleDestinoFinalMuebleResponse>>> CObtenerTramiteDestinoFinalAsync(long idDetalleSolicitud)
		{
			var response = await _servicioTramiteMueble.BObtenerTramiteDestinoFinalAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

	}
}
