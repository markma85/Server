using System.Text.Json;
using FluentValidation;
using Net_6_Assignment.Common;

namespace InnovateFuture.Api.Middleware
{
    public class FluentValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<FluentValidationMiddleware> _logger;

        public FluentValidationMiddleware(RequestDelegate next, ILogger<FluentValidationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Proceed to the next middleware or action
                await _next(context);
            }
            catch (ValidationException ex)
            {
                // Log the validation exception
                _logger.LogWarning("Validation exception occurred: {Errors}", ex.Errors.Select(e => e.ErrorMessage));

                // Build the error response
                var response = new CommonResponse<object>
                {
                    IsSuccess = false,
                    Errors = ex.Errors.Select(e => e.ErrorMessage).ToList()
                };

                // Write response to client
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                var jsonResponse = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}