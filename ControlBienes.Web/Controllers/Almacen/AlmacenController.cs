using ControlBienes.Business.Contrats.Almacen;
using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Almacen;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Almacen
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class AlmacenController : ControllerBase
	{
		private readonly IBusAlmacenComplemento _servicio;

		public AlmacenController(IBusAlmacenComplemento servicio)
		{
			_servicio = servicio;
		}

		[HttpGet("MetodoCosteo")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntAlmacenResponse>>>> CObtenerTodosMetodosCosteo()
		{
			var response = await _servicio.BObtenerMetodosCosteoAsync();
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Proveedor")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntAlmacenResponse>>>> CObtenerTodosProveedores()
		{
			var response = await _servicio.BObtenerProveedoresAsync();
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("ProgramaOperativo")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntAlmacenResponse>>>> CObtenerTodosProgramasOperativos()
		{
			var response = await _servicio.BObtenerProgramasOperativosAsync();
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("TipoMovimiento")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntAlmacenResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntAlmacenResponse>>>> CObtenerTodosTipoMovimiento()
		{
			var response = await _servicio.BObtenerTiposMovimientosAsync();
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
