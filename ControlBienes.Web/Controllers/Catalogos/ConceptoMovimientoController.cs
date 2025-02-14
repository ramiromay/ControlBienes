using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.ConceptoMovimiento;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Catalogos
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ConceptoMovimientoController : ControllerBase
	{
		private readonly IBusConceptoMovimiento _servicio;

		public ConceptoMovimientoController(IBusConceptoMovimiento servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]

		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntConceptoMovimientoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntConceptoMovimientoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntConceptoMovimientoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntConceptoMovimientoResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntConceptoMovimientoResponse>>>> CObtenerTodosConceptoMovimientos([FromQuery] bool? activo)
		{
			var response = await _servicio.BObtenerTodosAsync(activo);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntConceptoMovimientoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntConceptoMovimientoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntConceptoMovimientoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntConceptoMovimientoResponse>))]
		public async Task<ActionResult<EntityResponse<EntConceptoMovimientoResponse>>> CObtenerConceptoMovimiento(long id)
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
		public async Task<ActionResult<EntityResponse<int>>> CCrearCaracteristica([FromBody] EntConceptoMovimientoRequest request)
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
		public async Task<ActionResult<EntityResponse<int>>> CActualizarCaracteristica(long id, [FromBody] EntConceptoMovimientoRequest request)
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
		public async Task<ActionResult<EntityResponse<int>>> CActualizarEstatusCaracteristica(long id)
		{
			var response = await _servicio.BCambiarEstatusAsync(id);
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
