using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.ClaveVehicular;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Catalogos
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ClaveVehicularController : Controller
	{
		private readonly IBusClaveVehicular _servicio;

		public ClaveVehicularController(IBusClaveVehicular busColorServices)
		{
			_servicio = busColorServices;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntClaveVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntClaveVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntClaveVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntClaveVehicularResponse>))]
		public async Task<EntityResponse<IEnumerable<EntClaveVehicularResponse>>> CObtenerTodosColores()
		{

			return await _servicio.BObtenerTodosAsync();
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntClaveVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntClaveVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntClaveVehicularResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntClaveVehicularResponse>))]
		public async Task<EntityResponse<EntClaveVehicularResponse>> CObtenerColor(long id)
		{
			return await _servicio.BObtenerRegistroAsync(id);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CCrearColor([FromBody] EntClaveVehicularRequest request)
		{
			return await _servicio.BCrearAsync(request);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CActualizarColor(long id, [FromBody] EntClaveVehicularRequest request)
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
