using System.Net;
using System.Security.Cryptography;
using System.Text.Json;

namespace BTDS.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next , ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exceptio");
                context.Response.ContentType = "application/json";

                context.Response.StatusCode = ex switch
                {
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    ArgumentException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };

                var response = new
                {
                    Success = false,
                    Message = ex.Message,
                    Data=(object)null,
                    Errors = new[]
                    {
                        ex.Message
                    }
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
