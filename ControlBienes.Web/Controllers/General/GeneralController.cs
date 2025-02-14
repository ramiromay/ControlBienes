using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.General.Nacionalidad;
using ControlBienes.Entities.General.Nombramiento;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.General
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class GeneralController : ControllerBase
	{
		private readonly IBusNacionalidad _servicioNacionalidad;
		private readonly IBusNombramiento _servicioNombramiento;
		private readonly IBusBms _servicioBms;
		private readonly IBusCuenta _servicioCuenta;


		public GeneralController(IBusNacionalidad servicioNacionalidad, IBusNombramiento servicioNombramiento, IBusBms servicioBms, IBusCuenta servicioCuenta)
		{
			_servicioNacionalidad = servicioNacionalidad;
			_servicioNombramiento = servicioNombramiento;
			_servicioBms = servicioBms;
			_servicioCuenta = servicioCuenta;
		}

		[HttpGet("Nacionalidad")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntNacionalidadResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntNacionalidadResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntNacionalidadResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntNacionalidadResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntNacionalidadResponse>>>> CObtenerTodasNacionalidades()
		{
			var response = await _servicioNacionalidad.BObtenerTodadNacionalidades();
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Nombramiento")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntNombramientoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntNombramientoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntNombramientoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntNombramientoResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntNombramientoResponse>>>> CObtenerTodosNombramientoes()
		{
			var response = await _servicioNombramiento.BObtenerTodosNombramientos();
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("Bms")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<IEnumerable<EntBMSResponse>>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<IEnumerable<EntBMSResponse>>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<IEnumerable<EntBMSResponse>>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<IEnumerable<EntBMSResponse>>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<IEnumerable<EntBMSResponse>>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntBMSResponse>>>> CObtenerBmsAsync()
		{
			var response = await _servicioBms.BObtenerTodosBMSAsync();
			return StatusCode((int)response.StatusCode, response);
		}


		[HttpGet("Cuenta")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<IEnumerable<EntBMSResponse>>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<IEnumerable<EntBMSResponse>>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<IEnumerable<EntBMSResponse>>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<IEnumerable<EntBMSResponse>>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<IEnumerable<EntBMSResponse>>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntBMSResponse>>>> CObtenerCuentasAsync()
		{
			var response = await _servicioCuenta.ObtenerListaCuentaAsync();
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
