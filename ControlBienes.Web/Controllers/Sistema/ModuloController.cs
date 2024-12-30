using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.Sistema;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Sistema.Modulo.Modulo;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Sistema
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ModuloController : ControllerBase
	{
		private readonly IBusModulo _servicio;

		public ModuloController(IBusModulo servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntModuloResponse>))]
		public async Task<EntityResponse<IEnumerable<EntModuloResponse>>> CObtenerTodosColores()
		{

			return await _servicio.BObtenerTodosModulos();
		}
	}
}
