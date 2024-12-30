using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Catalogos
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CaracteristicaBienController : ControllerBase
	{
		private readonly IBusCaracteristicaBien _servicio;

		public CaracteristicaBienController(IBusCaracteristicaBien servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntCaracteristicaBienResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntCaracteristicaBienResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntCaracteristicaBienResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntCaracteristicaBienResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntCaracteristicaBienResponse>>>> CObtenerTodasCaracteristicas()
		{
			var response = await _servicio.BObtenerTodosAsync();
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntCaracteristicaBienResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntCaracteristicaBienResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntCaracteristicaBienResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntCaracteristicaBienResponse>))]
		public async Task<ActionResult<EntityResponse<EntCaracteristicaBienResponse>>> CObtenerCaracteristica(long id)
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
		public async Task<ActionResult<EntityResponse<int>>> CCrearCaracteristica([FromBody] EntCaracteristicaBienRequest request)
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
		public async Task<ActionResult<EntityResponse<int>>> CActualizarCaracteristica(long id, [FromBody] EntCaracteristicaBienRequest request)
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
