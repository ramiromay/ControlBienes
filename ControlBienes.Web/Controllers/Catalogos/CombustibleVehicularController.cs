using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.CombustibleVehicular;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Catalogos
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CombustibleVehicularController : ControllerBase
	{
		private readonly IBusCombustibleVehicular _servicio;

		public CombustibleVehicularController(IBusCombustibleVehicular servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntCombustibleVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntCombustibleVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntCombustibleVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntCombustibleVehicularResponse>))]
		public async Task<EntityResponse<IEnumerable<EntCombustibleVehicularResponse>>> CObtenerTodosColores()
		{

			return await _servicio.BObtenerTodosAsync();
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntCombustibleVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntCombustibleVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntCombustibleVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntCombustibleVehicularResponse>))]
		public async Task<EntityResponse<EntCombustibleVehicularResponse>> CObtenerColor(long id)
		{
			return await _servicio.BObtenerRegistroAsync(id);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CCrearColor([FromBody] EntCombustibleVehicularRequest request)
		{
			return await _servicio.BCrearAsync(request);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CActualizarColor(long id, [FromBody] EntCombustibleVehicularRequest request)
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
