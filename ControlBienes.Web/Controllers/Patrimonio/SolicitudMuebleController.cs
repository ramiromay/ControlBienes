using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Patrimonio
{
	[ApiController]
	[Route("api/v1/Patrimonio/[controller]")]
	public class SolicitudMuebleController : ControllerBase
	{
		private readonly IBusSolicitudMueble _servicio;

		public SolicitudMuebleController(IBusSolicitudMueble servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		public async Task<ActionResult<EntityResponse<IEnumerable<EntSolicitudMuebleResponse>>>> CObtenerTodosSolicitudMuebles(
			[FromQuery] long? periodo, 
			[FromQuery] bool? busquedaPorFecha, 
			[FromQuery] DateTime fechaInicio, 
			[FromQuery] DateTime? fechaFin, 
			[FromQuery] string unidadAdministrativa)
		{
			var response = await _servicio.BObtenerSolicitudesPorFiltroAsync(periodo, busquedaPorFecha, fechaInicio, fechaFin, unidadAdministrativa);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpGet("{id}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		public async Task<ActionResult<EntityResponse<EntSolicitudMuebleResponse>>> CObtenerSolicitudMueble(long id)
		{
			var response = await _servicio.BObtenerSolicitudAsync(id);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPost]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		public async Task<ActionResult<EntityResponse<int>>> CCrearSolicitudMueble([FromBody] EntSolicitudMuebleRequest request)
		{
			var response = await _servicio.BCrearSolicitudAsync(request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPut("{id}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		public async Task<ActionResult<EntityResponse<int>>> CActualizarSolicitudMueble(long id, [FromBody] EntSolicitudMuebleRequest request)
		{
			var response = await _servicio.BActualizarSolicitudAsync(id, request);
			return StatusCode((int)response.StatusCode, response);
		}

		[HttpPatch("{id}")]
		[AutorizacionSICBA(EnumPermiso.VisualizacionAdministradorCedulasBienesMuebles)]
		public async Task<ActionResult<EntityResponse<int>>> CCambiarEtapaSolicitudMueble(long id, [FromQuery] long? etapa)
		{
			var response = await _servicio.BCambiarEtapaSolicitudAsync(id, etapa);
			return StatusCode((int)response.StatusCode, response);
		}
	}
}
