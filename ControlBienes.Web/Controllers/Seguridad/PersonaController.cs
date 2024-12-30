using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Seguridad.Persona.Persona;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Seguridad
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class PersonaController : ControllerBase
	{
		private readonly IBusPersona _servicio;

		public PersonaController(IBusPersona servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntPersonaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntPersonaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntPersonaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntPersonaResponse>))]
		public async Task<EntityResponse<IEnumerable<EntPersonaResponse>>> CObtenerTodasPersonas()
		{

			return await _servicio.BObtenerTodasPersonasAsync();
		}
	}
}
