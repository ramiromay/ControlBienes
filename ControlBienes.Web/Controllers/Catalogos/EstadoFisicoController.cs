using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.EstadoFisico;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Catalogos
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class EstadoFisicoController : ControllerBase
	{
		private readonly IBusEstadoFisico _servicio;

		public EstadoFisicoController(IBusEstadoFisico servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntEstadoFisicoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntEstadoFisicoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntEstadoFisicoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntEstadoFisicoResponse>))]
		public async Task<EntityResponse<IEnumerable<EntEstadoFisicoResponse>>> CObtenerTodosColores([FromQuery] bool? activo)
		{

			return await _servicio.BObtenerTodosAsync(activo);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntEstadoFisicoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntEstadoFisicoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntEstadoFisicoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntEstadoFisicoResponse>))]
		public async Task<EntityResponse<EntEstadoFisicoResponse>> CObtenerColor(long id)
		{
			return await _servicio.BObtenerRegistroAsync(id);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CCrearColor([FromBody] EntEstadoFisicoRequest request)
		{
			return await _servicio.BCrearAsync(request);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CActualizarColor(long id, [FromBody] EntEstadoFisicoRequest request)
		{
			return await _servicio.BActualizarAsync(id, request);
		}

		[HttpPatch("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CActualizarEstatusColor(long id)
		{
			return await _servicio.BCambiarEstatusAsync(id);
		}
	}
}
