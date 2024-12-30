using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.General.TipoResponsable;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{

	[ApiController]
	[Route("api/v1/[controller]")]
	public class TipoResponsableController : ControllerBase
	{
		private readonly IBusTipoResponsable _servicio;

		public TipoResponsableController(IBusTipoResponsable servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntTipoResponsableResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntTipoResponsableResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntTipoResponsableResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntTipoResponsableResponse>))]
		public async Task<EntityResponse<IEnumerable<EntTipoResponsableResponse>>> CObtenerTodosTiposResponsables()
		{

			return await _servicio.BObtenerTodosTipoResponsableAsync();
		}
	}
}
