using ControlBienes.Entities.Constants;
using System.Net;

namespace ControlBienes.Business.Genericos
{
	public class EntityResponse<T>
	{
		public HttpStatusCode StatusCode { get; set; }
		public bool HasError { get; set; }
		public string? Message { get; set; }
		public EnumCodigoOperacion? Code { get; set; }
		public T? Result { get; set; }

		public EntityResponse() { }

		public void BadRequest(string message, EnumCodigoOperacion? code)
		{
			StatusCode = HttpStatusCode.BadRequest;
			HasError = true;
			Message = message;
			Code = code;
			Result = default;
		}

		public void NotFound(string message, EnumCodigoOperacion? code)
		{
			StatusCode = HttpStatusCode.NotFound;
			HasError = true;
			Message = message;
			Code = code;
			Result = default;
		}

		public void GatewayTimeout(string message, EnumCodigoOperacion? code)
		{
			StatusCode = HttpStatusCode.GatewayTimeout;
			HasError = true;
			Message = message;
			Code = code;
			Result = default;
		}

		public void InternalServerError(string message, EnumCodigoOperacion? code)
		{
			StatusCode = HttpStatusCode.InternalServerError;
			HasError = true;
			Message = message;
			Code = code;
			Result = default;
		}

		public void Unauthorized(string message, EnumCodigoOperacion? code)
		{
			StatusCode = HttpStatusCode.Unauthorized;
			HasError = true;
			Message = message;
			Code = code;
			Result = default;
		}

		public void Forbidden(string message, EnumCodigoOperacion? code)
		{
			StatusCode = HttpStatusCode.Forbidden;
			HasError = true;
			Message = message;
			Code = code;
			Result = default;

		}

		public void Conflict(string message, EnumCodigoOperacion? code)
		{
			StatusCode = HttpStatusCode.Conflict;
			HasError = true;
			Message = message;
			Code = code;
			Result = default;
		}

		public void Success(T result, EnumCodigoOperacion? code)
		{
			StatusCode = HttpStatusCode.OK;
			HasError = false;
			Message = EntMensajeConstant.OK;
			Code = code;
			Result = result;
		}

	}
}
