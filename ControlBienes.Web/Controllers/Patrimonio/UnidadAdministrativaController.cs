using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.General.UnidadAdministrativa;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class UnidadAdministrativaController : ControllerBase
	{
		private readonly IBusUnidadAdministrativa _servicio;

		public UnidadAdministrativaController(IBusUnidadAdministrativa servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntUnidadAdministrativaResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntUnidadAdministrativaResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntUnidadAdministrativaResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntUnidadAdministrativaResponse>))]
		public async Task<EntityResponse<IEnumerable<EntUnidadAdministrativaResponse>>> CObtenerTodosColores()
		{

			return await _servicio.BObtenerTodosUnidadesAdministrativasAsync();
		}
	}
}
