using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.General.Periodo;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.General
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class PeriodoController : ControllerBase
	{
		private readonly IBusPeriodo _servicio;
		public PeriodoController(IBusPeriodo servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntPeriodoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntPeriodoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntPeriodoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntPeriodoResponse>))]
		public async Task<EntityResponse<IEnumerable<EntPeriodoResponse>>> CObtenerTodosPeriodos()
		{

			return await _servicio.BObtenerPeriodosAsync();
		}
	}
}
