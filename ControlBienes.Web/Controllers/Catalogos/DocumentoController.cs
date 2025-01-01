using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.Documento;
using Microsoft.AspNetCore.Mvc;

namespace ControlBienes.Web.Controllers.Catalogos
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class DocumentoController : ControllerBase
	{
		private readonly IBusDocumento _servicio;

		public DocumentoController(IBusDocumento servicio)
		{
			_servicio = servicio;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDocumentoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDocumentoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDocumentoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDocumentoResponse>))]
		public async Task<EntityResponse<IEnumerable<EntDocumentoResponse>>> CObtenerTodosDocumentos([FromQuery] bool? activo)
		{

			return await _servicio.BObtenerTodosAsync(activo);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<EntDocumentoResponse>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<EntDocumentoResponse>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<EntDocumentoResponse>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<EntDocumentoResponse>))]
		public async Task<EntityResponse<EntDocumentoResponse>> CObtenerDocumento(long id)
		{
			return await _servicio.BObtenerRegistroAsync(id);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CCrearColor([FromBody] EntDocumentoRequest request)
		{
			return await _servicio.BCrearAsync(request);
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CActualizarDocumento(long id, [FromBody] EntDocumentoRequest request)
		{
			return await _servicio.BActualizarAsync(id, request);
		}

		[HttpPatch("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(EntityResponse<int>))]
		[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(EntityResponse<int>))]
		public async Task<EntityResponse<int>> CActualizarEstatusDocumento(long id)
		{
			return await _servicio.BCambiarEstatusAsync(id);
		}

	}
}
