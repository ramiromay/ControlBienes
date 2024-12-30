using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.Nacionalidad;
using ControlBienes.Entities.General.Nombramiento;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.General
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class GeneralController : ControllerBase
	{
		private readonly IBusNacionalidad _servicioNacionalidad;
		private readonly IBusNombramiento _servicioNombramiento;

		public GeneralController(IBusNacionalidad servicioNacionalidad, IBusNombramiento servicioNombramiento)
		{
			_servicioNacionalidad = servicioNacionalidad;
			_servicioNombramiento = servicioNombramiento;
		}

		[HttpGet("Nacionalidad")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntNacionalidadResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntNacionalidadResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntNacionalidadResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntNacionalidadResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntNacionalidadResponse>>>> CObtenerTodasNacionalidades()
		{
			var response = await _servicioNacionalidad.BObtenerTodadNacionalidades();
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Nombramiento")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntNombramientoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntNombramientoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntNombramientoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntNombramientoResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntNombramientoResponse>>>> CObtenerTodosNombramientoes()
		{
			var response = await _servicioNombramiento.BObtenerTodosNombramientos();
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
