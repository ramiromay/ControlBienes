using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Depreciacion;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/Patrimonio/[controller]")]

	public class DepreciacionController : ControllerBase
	{
		private readonly IBusDepreciacion _servicio;

		public DepreciacionController(IBusDepreciacion servicio){
			_servicio = servicio;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CDepreciarBienesAsync(
			[FromQuery] long? periodo,
			[FromQuery] long? mes,
			[FromQuery] long? tipoBien,
			[FromQuery] long? tipoDepreciacion,
			[FromQuery] string unidadAdministrativa,
			[FromQuery] string folioBien)
		{
			var response = await _servicio.BDepreciarBienes(periodo, mes, tipoBien, tipoDepreciacion, unidadAdministrativa, folioBien);
			return StatusCode((int)response.StatusCode, response);
		}


		[HttpGet("{idBien}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<ActionResult<EntityResponse<int>>> CObtenerDepreciacionBienesAsync(long idBien)
		{
			var response = await _servicio.BObtenerDepreciacionPorBienAsync(idBien);
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
