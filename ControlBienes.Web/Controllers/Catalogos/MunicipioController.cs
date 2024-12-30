using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.General.Municipio;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Catalogos
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class MunicipioController : ControllerBase
	{
		private readonly IBusMunicipio _servicio;

		public MunicipioController(IBusMunicipio servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntMunicipioResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntMunicipioResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntMunicipioResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntMunicipioResponse>))]
		public async Task<EntityResponse<IEnumerable<EntMunicipioResponse>>> CObtenerTodosMunicipios()
		{

			return await _servicio.BObtenerTodosMunicipiosAsync();
		}
	}
}
