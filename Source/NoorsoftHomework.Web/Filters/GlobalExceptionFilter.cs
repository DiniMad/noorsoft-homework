using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NoorsoftHomework.Web.Exceptions;
using NoorsoftHomework.Web.Resources.Shared;

namespace NoorsoftHomework.Web.Filters
{
    public static class GlobalExceptionFilter
    {
        public static IApplicationBuilder UseGlobalExceptionFilter(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder => builder.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                var response  = ResponseFactory(exception);
                context.Response.StatusCode = response.Status;
                await context.Response.WriteAsJsonAsync(response);
            }));

            return app;
        }

        private static ApiResponse ResponseFactory(Exception? exception)
        {
            const string dateOutOfRangeErrorMessage = "Date number is out of range";
            const string unexpectedErrorMessage     = "Something went wrong";
            var response = exception switch
            {
                DateOutOfRangeException => ApiResponse.Error(StatusCodes.Status400BadRequest,
                                                             dateOutOfRangeErrorMessage),
                _ => ApiResponse.Error(StatusCodes.Status500InternalServerError, unexpectedErrorMessage),
            };
            return response;
        }
    }
}