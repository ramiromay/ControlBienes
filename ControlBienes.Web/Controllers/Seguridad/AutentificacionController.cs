using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Seguridad.Autentificacion;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Seguridad
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class AutentificacionController : ControllerBase
	{
		private readonly IBusAutentificacion _servicio;

		public AutentificacionController(IBusAutentificacion servicio)
		{
			_servicio = servicio;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntAutentificacionResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntAutentificacionResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntAutentificacionResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntAutentificacionResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntAutentificacionResponse>))]
		public async Task<ActionResult<EntityResponse<EntAutentificacionResponse>>> CLogin([FromBody] EntAutentificacionRequest request)
		{
			var response = await _servicio.BLogin(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost("Validar")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntAutentificacionResponse>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<EntAutentificacionResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntAutentificacionResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntAutentificacionResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntAutentificacionResponse>))]
		public async Task<ActionResult<EntityResponse<EntAutentificacionResponse>>> CValidarToken([FromBody] string request)
		{
			var response = await _servicio.BValidateToken(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("correo")]
		public async Task<ActionResult<EntityResponse<int>>> CEnviarCorreoPrueba()
		{
			await _servicio.BEnviarCorreoPrueba();
			return StatusCode(200, 1);
		}
	}
}
