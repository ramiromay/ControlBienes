using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Seguridad.Autentificacion;
using ControlBienes.Entities.Seguridad.Empleado;
using ControlBienes.Entities.Seguridad.Rol;
using ControlBienes.Entities.Seguridad.Usuario;
using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using ControlBienes.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.Autentificacion
{
	public class BusAutentificacion : IBusAutentificacion
	{
		private readonly SignInManager<EntUsuario> _signInManager;
		private readonly IDatUsuarioPermiso _repositorioUsuarioPermiso;
		private readonly IDatEmpleado _repositorioEmpleado;
		private readonly IBusIdentityAccess _servicioIdentityAccess;
		private readonly EntJwtSettings _jwtSettings;
		private readonly ILogger<BusAutentificacion> _logger;
		private readonly EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkLogin;
		private readonly EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorLogin;

		public BusAutentificacion(
			 SignInManager<EntUsuario> signInManager,
			 RoleManager<EntRol> roleManager,
			 IDatUsuarioPermiso repositorioUsuarioPermiso,
			 IDatEmpleado repositorioEmpleado,
			 IOptions<EntJwtSettings> jwtSettings,
			 ILogger<BusAutentificacion> logger,
			 IBusIdentityAccess servicioIdentityAccess)
		{
			_signInManager = signInManager;
			_repositorioEmpleado = repositorioEmpleado;
			_repositorioUsuarioPermiso = repositorioUsuarioPermiso;
			_jwtSettings = jwtSettings.Value;
			_logger = logger;
			_servicioIdentityAccess = servicioIdentityAccess;
		}

		public async Task<EntityResponse<EntAutentificacionResponse>> BLogin(EntAutentificacionRequest request)
		{
			string nombreMetodo = nameof(BLogin);
			var resultado = new EntityResponse<EntAutentificacionResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para iniciar sesion");
			try
			{
				var signInResult = await _signInManager.PasswordSignInAsync(
					request.Usuario,
					request.Contrasenia,
					request.Recordarme,
					lockoutOnFailure: false
				);
				if (!signInResult.Succeeded)
				{
					throw new BusNoAutorizadoException("El Usuario o la Contraseña son incorrectas");
				}

				var includes = new List<Expression<Func<EntEmpleado, object>>>()
				{
					e => e.Persona!,
					e => e.Usuario!
				};
				var empleado = await _repositorioEmpleado.DObtenerRegistroAsync(e => e.Usuario.UserName.ToUpper() == request.Usuario.ToUpper(), includes);
				var usuarioPermisos = await _repositorioUsuarioPermiso.DObtenerTodosAsync(null, e => e.iIdUsuario == empleado.iIdUsuario);
				var token = BGenerateToken(empleado.Usuario, usuarioPermisos);
				var result = BusAutentificationMapping.Map(empleado, null, new JwtSecurityTokenHandler().WriteToken(token), usuarioPermisos);
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntAutentificacionResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error en el servidor al intentar iniciar sesión"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntAutentificacionResponse>> BValidateToken(string token)
		{
			string nombreMetodo = nameof(BValidateToken);
			var resultado = new EntityResponse<EntAutentificacionResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operación para validar el token");
			try
			{
				var validationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ClockSkew = TimeSpan.Zero,
					ValidIssuer = _jwtSettings.Issuer,
					ValidAudience = _jwtSettings.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key))
				};

				var tokenHandler = new JwtSecurityTokenHandler();
				SecurityToken validatedToken;

				var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
				var idUsuario = _servicioIdentityAccess.BObtenerIdUsuario(token);
				var includes = new List<Expression<Func<EntEmpleado, object>>>()
				{
					e => e.Persona!,
					e => e.Usuario!
				};
				var empleado = await _repositorioEmpleado.DObtenerRegistroAsync(e => e.iIdUsuario == idUsuario, includes);
				var usuarioPermisos = await _repositorioUsuarioPermiso.DObtenerTodosAsync(null, e => e.iIdUsuario == idUsuario);
				var result = BusAutentificationMapping.Map(empleado, null, token, usuarioPermisos);
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntAutentificacionResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrió un error al validar el token, es posible que ya haya expirado o se encuentre corrupto"
				);
			}

			return resultado;
		}

		private JwtSecurityToken BGenerateToken(EntUsuario usuario, IEnumerable<EntUsuarioPermiso> usuarioPermisos)
		{
			var permisosClaims = new List<Claim>();
			var usuarioClaims = new List<Claim>() 
			{ 
				new Claim(ClaimTypes.Name, usuario.UserName), 
				new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()) 
			};

			foreach (var permiso in usuarioPermisos)
			{
				permisosClaims.Add(new Claim(EntConstant.ClaimPermiso, permiso.iIdPermiso.ToString()));
			}

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Nickname, usuario.NormalizedUserName),
				new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
			}
			.Union(usuarioClaims)
			.Union(permisosClaims);

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
			var signInCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
			var jwtSecurityToken = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
				signingCredentials: signInCredential
			);

			return jwtSecurityToken;
		}
	}
}
