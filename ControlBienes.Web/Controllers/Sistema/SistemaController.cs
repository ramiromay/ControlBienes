using ControlBienes.Business.Contrats.Sistema;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Sistema.Catalogo.Catalogo;
using ControlBienes.Entities.Sistema.ColumnaTabla;
using ControlBienes.Entities.Sistema.Modulo.Modulo;
using ControlBienes.Entities.Sistema.SubModulo.SubModulo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Sistema
{

	[ApiController]
	[Route("api/v1/[controller]")]
	public class SistemaController : ControllerBase
	{
		private readonly IBusCatalogo _servicioCatalogo;
		private readonly IBusColumnaTabla _servicioColumnaTabla;
		private readonly IBusModulo _servicioModulo;
		private readonly IBusSubModulo _servicioSubModulo;

		public SistemaController(IBusCatalogo serviciocatalogo, IBusColumnaTabla servicioColumnaTabla, IBusModulo servicioModulo, IBusSubModulo servicioSubModulo)
		{
			_servicioCatalogo = serviciocatalogo;
			_servicioColumnaTabla = servicioColumnaTabla;
			_servicioModulo = servicioModulo;
			_servicioSubModulo = servicioSubModulo;
		}

		[HttpGet("Catalogo/{idModulo}")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntCatalogoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntCatalogoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntCatalogoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntCatalogoResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntCatalogoResponse>>>> CObtenerCatalogos(long idModulo)
		{
			var response = await _servicioCatalogo.BObtenerCatalogosAsync(idModulo);
			return StatusCode((int) response.StatusCode, response);
		}


		[HttpGet("Modulo")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntModuloResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntModuloResponse>>>> CObtenerModulos()
		{
			var response = await _servicioModulo.BObtenerTodosModulos();
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("SubModulo")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntSubModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntSubModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntSubModuloResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntSubModuloResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntSubModuloResponse>>>> CObtenerTodosColores()
		{
			var response = await _servicioSubModulo.BObtenerTodosSubModulos();
			return StatusCode((int) response.StatusCode, response);
		}

		[HttpGet("ColumnaTabla/Catalogo/{idCatalogo}")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntColumnaTablaResponse>>>> CObtenerColumnasTablaCatalogo(long idCatalogo)
		{
			var response = await _servicioColumnaTabla.BObtenerColumnasTablaCatalogoAsync(idCatalogo);
			return StatusCode((int) response.StatusCode, response);
		}

		[HttpGet("ColumnaTabla/SubModulo/{idSubModulo}")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntColumnaTablaResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntColumnaTablaResponse>>>> CObtenerColumnasTablaSubModulo(long idSubModulo)
		{
			var response = await _servicioColumnaTabla.BObtenerColumnasTablaSubModuloAsync(idSubModulo);
			return StatusCode((int) response.StatusCode, response);
		}
	}
}
