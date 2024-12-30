using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Seguridad.Permiso;
using ControlBienes.Entities.Seguridad.Rol;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Seguridad
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class SeguridadController : ControllerBase
	{
		private readonly IBusRol _servicioRol;
		private readonly IBusPermiso _servicioPermiso;

		public SeguridadController(IBusRol servicioRol, IBusPermiso servicioPermiso)
		{
			_servicioRol = servicioRol;
			_servicioPermiso = servicioPermiso;
		}

		[HttpGet("Rol")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntRolResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntRolResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntRolResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntRolResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntRolResponse>>>> CObtenerTodosRoles()
		{
			var response = await _servicioRol.BObtenerTodosRolesAsync();
			return StatusCode((int)response.StatusCode, response);
		}


		[HttpGet("Permiso")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntPermisoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntPermisoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntPermisoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntPermisoResponse>))]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntPermisoResponse>>>> CObtenerTodosPermisoes()
		{
			var response = await _servicioPermiso.BObtenerTodosPermisoAsync();
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
