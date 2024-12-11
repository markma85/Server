using InnovateFuture.Api.Common;
using InnovateFuture.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InnovateFuture.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;
    private readonly IWebHostEnvironment _environment;

    public ExceptionFilter(ILogger<ExceptionFilter> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var response = new CommonResponse<object>
        {
            IsSuccess = false,
            Errors = new List<string>()
        };

        switch (exception)
        {
            case FluentValidation.ValidationException validationException:
                response.Errors.AddRange(validationException.Errors
                    .Select(e => e.ErrorMessage).Distinct());
                context.Result = new BadRequestObjectResult(response);
                _logger.LogWarning("Validation exception: {Errors}", response.Errors);
                break;
            
            case ArgumentException:
                response.Errors.Add(exception.Message);
                context.Result = new BadRequestObjectResult(response);
                _logger.LogWarning("Bad request exception: {Message}", exception.Message);
                break;
            
            case BadRequestException:
                response.Errors.Add(exception.Message);
                context.Result = new BadRequestObjectResult(response);
                _logger.LogWarning("Bad request exception: {Message}", exception.Message);
                break;
            
            case NotFoundException:
                response.Errors.Add(exception.Message);
                context.Result = new NotFoundObjectResult(response);
                _logger.LogWarning("Not found exception: {Message}", exception.Message);
                break;

            case UnauthorizedException:
                response.Errors.Add(exception.Message);
                context.Result = new UnauthorizedObjectResult(response);
                _logger.LogWarning("Unauthorized exception: {Message}", exception.Message);
                break;

            default:
                response.Errors.Add("An unknown error occurred");
                if (_environment.IsDevelopment())
                {
                    response.Errors.Add($"Exception Details: {exception}");
                }

                context.Result = new JsonResult(response)
                {
                    StatusCode = 500
                };
                _logger.LogError("Unexpected error: {Message}", exception.Message);
                break;
        }

        context.ExceptionHandled = true;
    }
}