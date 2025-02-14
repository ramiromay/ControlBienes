using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/Patrimonio/[controller]")]
	public class InventarioVehiculoController : ControllerBase
	{
		private readonly IBusInventarioVehiculo _servicio;

		public InventarioVehiculoController(IBusInventarioVehiculo servicio)
		{
			_servicio = servicio;
		}

		[HttpGet("{idBien}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionInventarioBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<EntBienMuebleResponse>>> CObtenerBienAsync(long idBien)
		{
			var response = await _servicio.BObtenerBienPorIdAsync(idBien);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("{idBien}/Historial")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionInventarioBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<IEnumerable<EntSeguimientoResponse>>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<IEnumerable<EntSeguimientoResponse>>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<IEnumerable<EntSeguimientoResponse>>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<IEnumerable<EntSeguimientoResponse>>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<IEnumerable<EntSeguimientoResponse>>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntHistorialReponse>>>> CHistorialBienAsync(long idBien)
		{
			var response = await _servicio.BObtenerHistorialBienPorIdAsync(idBien);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet]
		[AutorizacionSICBA(EnumPermiso.VisualizacionInventarioBienesVehiculares)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>>> CObtenerTramitesPorSolicitudAsync(
			[FromQuery] long? periodo,
			[FromQuery] string unidadAdministrativa,
			[FromQuery] bool? estadoBien,
			[FromQuery] bool? busquedaPorTipoBien,
			[FromQuery] long? idBusqueda,
			[FromQuery] long? nivelArticulo,
			[FromQuery] bool? busquedaPorFecha,
			[FromQuery] DateTime? fechaInicio,
			[FromQuery] DateTime? fechaFin)
		{
			var response = await _servicio.BObtenerBienesPorFiltroAsync(periodo, unidadAdministrativa, estadoBien,
						busquedaPorTipoBien, idBusqueda, nivelArticulo, busquedaPorFecha, fechaInicio, fechaFin);
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
