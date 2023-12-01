using Newtonsoft.Json;
using SortedCodingTest.Api.Models;
using SortedCodingTest.Application.Exceptions;
using System.Net;

namespace SortedCodingTest.Api
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError("Error occured: {message}", ex.Message);

            var errorResponse = new ErrorResponse();

            if (ex is AppException serviceException)
            {
                context.Response.StatusCode = (int)serviceException.StatusCode;
                errorResponse.Message = ex.Message;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse.Message = ErrorMessages.InternalServerError;
            }

            var response = JsonConvert.SerializeObject(errorResponse);

            await context.Response.WriteAsync(response);
        }
    }
}