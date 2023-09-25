using System.Net;
using FluentValidation;
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
            catch(ValidationException e)
            {
                var validationErrors = e.Errors.Where(x => x is not null)
                    .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessage) => new
                    { 
                        Key = propertyName,
                        Values = errorMessage.Distinct().ToArray()
                    })    
                    .ToDictionary(x => x.Key, x => x.Values);
                await GenerateExceptionResponse(e, context, (int)HttpStatusCode.UnprocessableEntity, "Validation error", validationErrors);

            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                await GenerateExceptionResponse(e, context, (int)HttpStatusCode.InternalServerError, "Something Went wrong");
            }
        }

        private async Task GenerateExceptionResponse(Exception e, HttpContext context, int statusCode, string details, Dictionary<string, string[]>? validationErrors = default)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ErrorDetails(context.Response.StatusCode, e.Message, details);

            if (validationErrors is not null)
            {
                response.ValidationErrors = validationErrors;
            }

            var opt = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, opt);

            await context.Response.WriteAsync(json);
        }
        
    }
}
