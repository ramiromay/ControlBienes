using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.IdentityAccess
{
	public class BusIdentityAccess : IBusIdentityAccess
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public BusIdentityAccess(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}
		public long BObtenerIdUsuario()
		{
			var idUsuario = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
			return long.Parse(idUsuario);
		}

		public long BObtenerIdUsuario(string token)
		{
			var handler = new JwtSecurityTokenHandler();
			var jwtToken = handler.ReadJwtToken(token);
			var idUsuario = jwtToken?.Claims
				.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

			return long.Parse(idUsuario);
		}

	}
}
