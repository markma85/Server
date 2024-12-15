using System.ComponentModel.DataAnnotations;
using InnovateFuture.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Net_6_Assignment.Common;

namespace InnovateFuture.Api.Filters;

    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var response = new CommonResponse<object>
            {
                IsSuccess = false,
                Errors = new List<string>()
            };

        if (exception is BadRequestException)
        {
            response.Errors.Add(exception.Message);
            context.Result = new BadRequestObjectResult(response);
            _logger.LogWarning("Validation exception: {Message}", exception.Message);
        }
        else if (exception is NotFoundException)
        {
            response.Errors.Add(exception.Message);
            context.Result = new NotFoundObjectResult(response);
            _logger.LogWarning("Not found exception: {Message}", exception.Message);
        }
        else if (exception is UnauthorizedException)
        {
            response.Errors.Add(exception.Message);
            context.Result = new UnauthorizedObjectResult(response);
            _logger.LogWarning("Unauthorized exception: {Message}", exception.Message);
        }
        else if (exception is FluentValidation.ValidationException)
        {
            response.Errors.Add(exception.Message);
            context.Result = new BadRequestObjectResult(response);
            _logger.LogWarning("Validation exception: {Message}", exception.Message);
        }
        else
        {
            // response.Errors.Add("An unknown error occurred");
            response.Errors.Add(exception.Message);
            context.Result = new JsonResult(response)
            {
                StatusCode = 500
            };
            _logger.LogError("Unexpected error: {Message}", exception.Message);
        }

            context.ExceptionHandled = true;
        }
    }
