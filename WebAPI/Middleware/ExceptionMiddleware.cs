using System.Net;
using System.Text.Json;
using WebAPI.Models;

namespace WebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this._next = next;
            this._logger = logger;
            this._env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                await GenerateExpectionResponse(e, context, (int)HttpStatusCode.InternalServerError, "Something Went wrong");
            }
        }

        private async Task GenerateExpectionResponse(Exception e, HttpContext context, int statusCode, string details)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ErrorDetails(context.Response.StatusCode, e.Message, details);

            var opt = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, opt);

            await context.Response.WriteAsync(json);
        }
        
    }
}
