using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleDesincorporacion;
using ControlBienes.Entities.Patrimonio.DetalleDestinoFinal;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleMovimiento;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/Patrimonio/[controller]")]
	public class TramiteVehiculoController : ControllerBase
	{
		private readonly IBusTramiteVehiculo _servicioVehiculo;

		public TramiteVehiculoController(IBusTramiteVehiculo servicioTramiteMueble)
		{
			_servicioVehiculo = servicioTramiteMueble;
		}

		[HttpPatch("{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCambiarEtapaTramiteAsync(long idDetalleSolicitud, [FromQuery] long? etapa)
		{
			var response = await _servicioVehiculo.BCambiarEtapaTramiteAsync(idDetalleSolicitud, etapa);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("Alta")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteAlta([FromBody] EntDetalleAltaVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BCrearTramiteAltaAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Alta/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteAlta(long idDetalleSolicitud, [FromBody] EntDetalleAltaVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BActualizarTramiteAltaAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Alta/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleAltaMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleAltaMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleAltaMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleAltaMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleAltaMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleAltaVehiculoRequest>>> CObtenerTramiteAlta(long idDetalleSolicitud)
		{
			var response = await _servicioVehiculo.BObtenerTramiteAltaAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}


		[HttpPost("Modificacion")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteModificacion([FromBody] EntDetalleModificacionVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BCrearTramiteModificacionAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Modificacion/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteModificacion(long idDetalleSolicitud, [FromBody] EntDetalleModificacionVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BActualizarTramiteModificacionAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Modificacion/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleModificacionVehiculoResponse>>> CObtenerTramiteModificacion(long idDetalleSolicitud)
		{
			var response = await _servicioVehiculo.BObtenerTramiteModificacionAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}


		[HttpPost("Baja")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteBajaAsync([FromBody] EntDetalleBajaVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BCrearTramiteBajaAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Baja/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteModificacion(long idDetalleSolicitud, [FromBody] EntDetalleBajaVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BActualizarTramiteBajaAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Baja/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleBajaMuebleResponse>>> CObtenerTramiteBajaAsync(long idDetalleSolicitud)
		{
			var response = await _servicioVehiculo.BObtenerTramiteBajaAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("Movimiento")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteMovimientoAsync([FromBody] EntDetalleMovimientoVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BCrearTramiteMovimientoAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Movimiento/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteMovimiento(long idDetalleSolicitud, [FromBody] EntDetalleMovimientoVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BActualizarTramiteMovimientoAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Movimiento/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleMovimientoVehiculoResponse>>> CObtenerTramiteMovimientoAsync(long idDetalleSolicitud)
		{
			var response = await _servicioVehiculo.BObtenerTramiteMovimientoAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("Desincorporacion")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteDesincorporacionAsync([FromBody] EntDetalleDesincorporacionVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BCrearTramiteDesincorporacionAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("Desincorporacion/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteDesincorporacion(long idDetalleSolicitud, [FromBody] EntDetalleDesincorporacionVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BActualizarTramiteDesincorporacionAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Desincorporacion/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleDesincorporacionMuebleResponse>>> CObtenerTramiteDesincorporacionAsync(long idDetalleSolicitud)
		{
			var response = await _servicioVehiculo.BObtenerTramiteDesincorporacionAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("DestinoFinal")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearTramiteDestinoFinalnAsync([FromBody] EntDetalleDestinoFinalVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BCrearTramiteDestinoFinalAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("DestinoFinal/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarTramiteDestinoFinal(long idDetalleSolicitud, [FromBody] EntDetalleDestinoFinalVehiculoRequest request)
		{
			var response = await _servicioVehiculo.BActualizarTramiteDestinoFinalAsync(idDetalleSolicitud, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("DestinoFinal/{idDetalleSolicitud}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDetalleModificacionMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntDetalleDestinoFinalVehiculoResponse>>> CObtenerTramiteDestinoFinalAsync(long idDetalleSolicitud)
		{
			var response = await _servicioVehiculo.BObtenerTramiteDestinoFinalAsync(idDetalleSolicitud);
			return StatusCode((int)response.StatusCode, response);
		}

	}
}
