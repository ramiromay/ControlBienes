using ControlBienes.Business.Contrats.Almacen;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Almacen.MovimientoBien;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Almacen
{
	[Route("api/v1/Almacen/[controller]")]
	[ApiController]

	public class MovimientoController : ControllerBase
	{
		private readonly IBusMovimientoBien _servicio;

		public MovimientoController(IBusMovimientoBien servicio)
		{
			_servicio = servicio;
		}


		[HttpGet]
		//[AutorizacionSICBA(EnumPermiso.VisualizacionEntradasSalidas)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntSolicitudInmuebleResponse>>>> CObtenerTodosMovimientos(
			[FromQuery] long? periodo,
			[FromQuery] bool? busquedaPorFecha,
			[FromQuery] DateTime fechaInicio,
			[FromQuery] DateTime? fechaFin,
			[FromQuery] long almacen)
		{
			var response = await _servicio.BObtenerMovimientosPorFiltroAsync(periodo, busquedaPorFecha, fechaInicio, fechaFin, almacen);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("{id}")]
		//[AutorizacionSICBA(EnumPermiso.VisualizacionEntradasSalidas)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntSolicitudInmuebleResponse>>> CObtenerMovimeinto(long id)
		{
			var response = await _servicio.BObtenerMovimientoAsync(id);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("{id}/Etapas")]
		//[AutorizacionSICBA(EnumPermiso.VisualizacionEntradasSalidas)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntSolicitudMuebleResponse>))]
		public async Task<ActionResult<EntityResponse<EntSolicitudInmuebleResponse>>> CObtenerEtapasPorMovimiento(long id)
		{
			var response = await _servicio.BObtenerEtapasPorMovimientoAsync(id);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost]
		//[AutorizacionSICBA(EnumPermiso.VisualizacionEntradasSalidas)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearMovimiento([FromBody] EntMovimientoBienRequest request)
		{
			var response = await _servicio.BCrearMovimientoAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("{id}")]
		//[AutorizacionSICBA(EnumPermiso.VisualizacionEntradasSalidas)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarMovimiento(long id, [FromBody] EntMovimientoBienRequest request)
		{
			var response = await _servicio.BActualizarMovimientoAsync(id, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPatch("{id}")]
		//[AutorizacionSICBA(EnumPermiso.VisualizacionEntradasSalidas)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCambiarEtapaMovimiento(long id, [FromQuery] long? etapa)
		{
			var response = await _servicio.BCambiarEtapaMovimientoAsync(id, etapa);
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
