using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Almacen.TipoMovimiento;
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
                _logger.LogInformation("Llego al middleward");
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Se lanzo la execpcion");

				EntityResponse<string> resultado = BusExceptionHandler.Handle<string>(
					_logger,
					ex,
					null,
					nameof(InvokeAsync),
					"Ocurrio un error en la solicitud"
				);

				context.Response.ContentType = "application/json";
                resultado.Result = JsonConvert.SerializeObject(resultado);
                await context.Response.WriteAsync(resultado.Result);

            }
        }



    }
}
