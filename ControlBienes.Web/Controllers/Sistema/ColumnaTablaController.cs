using ControlBienes.Business.Contrats.Sistema;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Sistema.ColumnaTabla;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Sistema
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ColumnaTablaController : ControllerBase
	{
		private readonly IBusColumnaTabla _servicio;

		public ColumnaTablaController(IBusColumnaTabla servicio)
		{
			_servicio = servicio;
		}

		[HttpGet("Catalogo/{idCatalogo}")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		public async Task<EntityResponse<IEnumerable<EntColumnaTablaResponse>>> CObtenerColumnasTablaCatalogo(long idCatalogo)
		{

			return await _servicio.BObtenerColumnasTablaCatalogoAsync(idCatalogo);
		}

		[HttpGet("SubModulo/{idSubModulo}")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		public async Task<EntityResponse<IEnumerable<EntColumnaTablaResponse>>> CObtenerColumnasTablaSubModulo(long idSubModulo)
		{

			return await _servicio.BObtenerColumnasTablaCatalogoAsync(idSubModulo);
		}
	}
}
