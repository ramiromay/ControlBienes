using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class MotivoTramiteController : ControllerBase
	{
		private readonly IBusMotivoTramite _servicio;

		public MotivoTramiteController(IBusMotivoTramite servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntMotivoTramiteResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntMotivoTramiteResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntMotivoTramiteResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntMotivoTramiteResponse>))]
		public async Task<EntityResponse<IEnumerable<EntMotivoTramiteResponse>>> CObtenerTodosMotivosTramites()
		{

			return await _servicio.BObtenerTodosMotivosTramites();
		}
	}
}
