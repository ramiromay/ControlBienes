using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class TipoTramiteController : ControllerBase
	{
		private readonly IBusTipoTramite _servicio;

		public TipoTramiteController(IBusTipoTramite servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntTipoTramiteResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntTipoTramiteResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntTipoTramiteResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntTipoTramiteResponse>))]
		public async Task<EntityResponse<IEnumerable<EntTipoTramiteResponse>>> CObtenerTodosTiposTramites()
		{

			return await _servicio.BObtenerTodosTiposTramites();
		}
	}
}
