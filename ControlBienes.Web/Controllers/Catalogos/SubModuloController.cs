using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.Sistema;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Sistema.SubModulo.SubModulo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Catalogos
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class SubModuloController : ControllerBase
	{
		private readonly IBusSubModulo _servicio;

		public SubModuloController(IBusSubModulo servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntSubModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntSubModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntSubModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntSubModuloResponse>))]
		public async Task<EntityResponse<IEnumerable<EntSubModuloResponse>>> CObtenerTodosColores()
		{

			return await _servicio.BObtenerTodosSubModulos();
		}
	}
}
