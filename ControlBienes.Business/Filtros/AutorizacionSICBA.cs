using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Contrats.Sistema;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class AutorizacionSICBA : Attribute, IAuthorizationFilter
{
	private readonly EnumPermiso[] _permisos;
	const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeErrorFiltroAutentificacion;

	public AutorizacionSICBA(params EnumPermiso[] permisos)
	{
		_permisos = permisos;
	}

	public void OnAuthorization(AuthorizationFilterContext context)
	{
		var response = new EntityResponse<int>();
		try
		{
			var dbHealthService = context.HttpContext.RequestServices.GetService<IDatabaseHealthService>();
			if (dbHealthService == null || !dbHealthService.IsDatabaseConnectedAsync().GetAwaiter().GetResult())
			{
				response.InternalServerError("No se pudo establecer conexión con la base de datos para verificar su identidad y sus permisos de usuario", _code);
				context.Result = new JsonResult(response)
				{
					StatusCode = StatusCodes.Status500InternalServerError
				};
				return;
			}


			var user = context.HttpContext.User;
			if (!user.Identity.IsAuthenticated)
			{
				response.Unauthorized("Debe verificar su identidad para acceder a este recurso", _code);
				context.Result = new JsonResult(response)
				{
					StatusCode = StatusCodes.Status401Unauthorized
				};

				return;
			}

			if (_permisos.Length == 0)
			{
				return;
			}

			var permissionService = context.HttpContext.RequestServices.GetService<IBusUsuarioPermiso>();
			if (permissionService == null)
			{
				response.InternalServerError("En este momento no se puedo verificar sus permisos", _code);
				context.Result = new JsonResult(response)
				{
					StatusCode = StatusCodes.Status500InternalServerError
				};
				return;
			}

			var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (string.IsNullOrEmpty(userId))
			{
				response.Unauthorized("No se puedo obtener el identificador del usuario", _code);
				context.Result = new JsonResult(response)
				{
					StatusCode = StatusCodes.Status401Unauthorized
				};
				return;
			}


			var tienePermiso = permissionService.HasPermisoAsync(long.Parse(userId), _permisos).GetAwaiter().GetResult();
			if (!tienePermiso)
			{
				response.Forbidden("No tiene permiso para acceder a este recurso", _code);
				context.Result = new JsonResult(response)
				{
					StatusCode = StatusCodes.Status403Forbidden
				};
			}
		}
		catch (Exception ex)
		{
			response.InternalServerError("Ocurrio un error el servidor al intentar verificar su identidad y sus permisos", _code);
			context.Result = new JsonResult(response)
			{
				StatusCode = StatusCodes.Status500InternalServerError
			};
		}
	}
}

