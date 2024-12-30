using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Titular;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Catalogos
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class TitularController : ControllerBase
	{
		private readonly IBusTitular _servicio;

		public TitularController(IBusTitular servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntTitularResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntTitularResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntTitularResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntTitularResponse>))]
		public async Task<EntityResponse<IEnumerable<EntTitularResponse>>> CObtenerTodosTitulares()
		{

			return await _servicio.BObtenerTodosAsync();
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntTitularResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntTitularResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntTitularResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntTitularResponse>))]
		public async Task<EntityResponse<EntTitularResponse>> CObtenerTitular(long id)
		{
			return await _servicio.BObtenerRegistroAsync(id);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CCrearTitular([FromBody] EntTitularRequest request)
		{
			return await _servicio.BCrearAsync(request);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CActualizarTitular(long id, [FromBody] EntTitularRequest request)
		{
			return await _servicio.BActualizarAsync(id, request);
		}

		[HttpPatch("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CActualizarEstatusTitular(long id)
		{
			return await _servicio.BCambiarEstatusAsync(id);
		}
	}
}
