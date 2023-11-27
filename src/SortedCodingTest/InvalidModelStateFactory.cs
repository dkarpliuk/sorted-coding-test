﻿using Microsoft.AspNetCore.Mvc;
using SortedCodingTest.Models;
using SortedCodingTest.Services.Exceptions;

namespace SortedCodingTest
{
    public static class InvalidModelStateFactory
    {
        public static IServiceCollection AddInvalidModelStateFactory(this IServiceCollection services)
        {
            return services.PostConfigure<ApiBehaviorOptions>(options => options.InvalidModelStateResponseFactory = HandleErrors);
        }

        private static IActionResult HandleErrors(ActionContext context)
        {
            var response = new ErrorResponse
            {
                Message = ErrorMessages.InvalidRequest,
                Detail = context.ModelState
                    .SelectMany(entry => entry.Value?.Errors.Select(x => (entry.Key, x.ErrorMessage)) ?? Array.Empty<(string, string)>())
                    .Select(x => new ErrorDetail { PropertyName = x.Key, Message = x.ErrorMessage })
                    .OrderBy(x => x.PropertyName)
                    .ToList()
            };

            return new BadRequestObjectResult(response);
        }
    }
}