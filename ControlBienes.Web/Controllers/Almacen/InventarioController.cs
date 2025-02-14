using ControlBienes.Business.Contrats.Almacen;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Almacen
{
	[ApiController]
	[Route("api/v1/Almacen/[controller]")]

	public class InventarioController : ControllerBase
	{
		private readonly IBusInventarioAlmacen _servicio;

		public InventarioController(IBusInventarioAlmacen servicio)
		{
			_servicio = servicio;
		}

		[HttpGet("{idBien}")]
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

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>>> CObtenerTramitesPorSolicitudAsync(
			[FromQuery] long? periodo,
			[FromQuery] long almacen,
			[FromQuery] bool? busquedaPorFecha,
			[FromQuery] DateTime? fechaInicio,
			[FromQuery] DateTime? fechaFin)
		{
			var response = await _servicio.BObtenerBienesPorFiltroAsync(periodo, almacen, busquedaPorFecha, fechaInicio, fechaFin);
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
