using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Constants;
using Newtonsoft.Json;
using System.Net;

namespace ControlBienes.Web.Middleware
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error en la peticion");
                _logger.LogError(ex, ex.Message);
                EntityResponse<string> resultado = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Ocurrio un error interno: ",
                    HasError = true,
                    Code = EnumCodigoOperacion.CodeErrorColor
                };

                context.Response.ContentType = "application/json";

                //switch (ex)
                //{
                //    case ValidationException validationException:
                //        statusCode = (int)HttpStatusCode.BadRequest;
                //        var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                //        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, validationJson));
                //        break;
                //    default:
                //        break;
                //}

                resultado.Result = JsonConvert.SerializeObject(resultado);
                await context.Response.WriteAsync(resultado.Result);

            }
        }

    }
}
