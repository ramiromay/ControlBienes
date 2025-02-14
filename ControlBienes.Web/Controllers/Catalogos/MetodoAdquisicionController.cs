using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.MetodoAdquisicion;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Catalogos
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class MetodoAdquisicionController : ControllerBase
	{
		private readonly IBusMetodoAdquisicion _servicio;

		public MetodoAdquisicionController(IBusMetodoAdquisicion servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntMetodoAdquisicionResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntMetodoAdquisicionResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntMetodoAdquisicionResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntMetodoAdquisicionResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntMetodoAdquisicionResponse>>>> CObtenerTodosMetodoAdquisiciones([FromQuery] bool? activo)
		{
			var response = await _servicio.BObtenerTodosAsync(activo);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntMetodoAdquisicionResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntMetodoAdquisicionResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntMetodoAdquisicionResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntMetodoAdquisicionResponse>))]
		public async Task<ActionResult<EntityResponse<EntMetodoAdquisicionResponse>>> CObtenerMetodoAdquisicion(long id)
		{
			var response = await _servicio.BObtenerRegistroAsync(id);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CCrearMetodoAdquisicion([FromBody] EntMetodoAdquisicionRequest request)
		{
			var response = await _servicio.BCrearAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarMetodoAdquisicion(long id, [FromBody] EntMetodoAdquisicionRequest request)
		{
			var response = await _servicio.BActualizarAsync(id, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPatch("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarEstatus(long id)
		{
			var response = await _servicio.BCambiarEstatusAsync(id);
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
