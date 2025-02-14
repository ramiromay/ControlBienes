using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Constants;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net;

namespace ControlBienes.Business.Exceptions
{
	public static class BusExceptionHandler
	{

		public static EntityResponse<T> Handle<T>(ILogger _logger, Exception ex, EnumCodigoOperacion? code, string nombreMetodo, string mensaje)
		{
			var resultado = new EntityResponse<T>();
			switch (ex)
			{
				case BusNoAutorizadoException busNoAutorizadoException:
					resultado.Unauthorized(busNoAutorizadoException.Message, code);
					_logger.LogError($"{(long)code} Error en {nombreMetodo}: al intentar verificar su identidad  ({busNoAutorizadoException.Message})");
					break;
				case BusRequestException busRequestException:
					resultado.BadRequest(busRequestException.Errores, code);
					_logger.LogError($"{(long)code} Error en {nombreMetodo}: {busRequestException.Message} ({busRequestException.Errores})");
					break;
				case BusConflictoException busConflictoException:
					resultado.Conflict(busConflictoException.Message, code);
					_logger.LogError($"{(long)code} Error en {nombreMetodo}: {busConflictoException.Message}");
					break;
				case SqlException sqlException:
					resultado.GatewayTimeout(EntMensajeConstant.ErrorTransaccionBD, code);
					_logger.LogError($"{(long)code} Error en {nombreMetodo}: {sqlException.Message}");
					break;
				case SecurityTokenExpiredException securityTokenExpiredException:
					var expiracion = securityTokenExpiredException.Expires.ToString("dd/MM/yyyy HH:mm:ss");
					var mensajeToken = string.Format(EntMensajeConstant.TokenExpirado, expiracion);
					resultado.Unauthorized(mensajeToken, code);
					_logger.LogError($"{(long)code} Error en {nombreMetodo}: {mensajeToken}");
					break;
				case SecurityTokenValidationException securityTokenValidationException:
					resultado.Unauthorized(EntMensajeConstant.TokenInvalido, code);
					_logger.LogError($"{(long)code} Error en {nombreMetodo}: {securityTokenValidationException.Message}");
					break;
				case Exception exception:
					resultado.InternalServerError(mensaje, code);
					_logger.LogError($"{(long)code} Error en {nombreMetodo}: {mensaje} -> {exception.Message}");
					break;
			}
			return resultado;
		}

	}
}
