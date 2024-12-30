using ControlBienes.Business.Contrats.Sistema;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Entities.Sistema.Catalogo.Catalogo;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Sistema
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CatalogoController : ControllerBase
	{

		private readonly IBusCatalogo _servicio;

		public CatalogoController(IBusCatalogo servicio)
		{
			_servicio = servicio;
		}

		[HttpGet("{idModulo}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntCatalogoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntCatalogoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntCatalogoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntCatalogoResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntCatalogoResponse>>>> CObtenerTodosCatalogosPorModulo(long idModulo)
		{
			var response = await _servicio.BObtenerCatalogosAsync(idModulo);
			return StatusCode((int) response.StatusCode, response);
		}
	}
}
