using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/Patrimonio/[controller]")]
	public class SolicitudVehiculoController : ControllerBase
	{
		private readonly IBusSolicitudVehiculo _servicio;

		public SolicitudVehiculoController(IBusSolicitudVehiculo servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntSolicitudVehiculoResponse>>>> CObtenerTodosSolicitud(
			[FromQuery] long? periodo, 
			[FromQuery] bool? busquedaPorFecha, 
			[FromQuery] DateTime fechaInicio, 
			[FromQuery] DateTime? fechaFin, 
			[FromQuery] string unidadAdministrativa)
		{
			var response = await _servicio.BObtenerSolicitudesPorFiltroAsync(periodo, busquedaPorFecha, fechaInicio, fechaFin, unidadAdministrativa);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("{id}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntSolicitudVehiculoResponse>>> CObtenerSolicitud(long id)
		{
			var response = await _servicio.BObtenerSolicitudAsync(id);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearSolicitud([FromBody] EntSolicitudVehiculoRequest request)
		{
			var response = await _servicio.BCrearSolicitudAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("{id}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarSolicitud(long id, [FromBody] EntSolicitudVehiculoRequest request)
		{
			var response = await _servicio.BActualizarSolicitudAsync(id, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPatch("{id}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCambiarEtapaSolicitud(long id, [FromQuery] long? etapa)
		{
			var response = await _servicio.BCambiarEtapaSolicitudAsync(id, etapa);
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
