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
                var (statusCode, data)      = ResponseFactory(exception);
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(data);
            }));

            return app;
        }

        private static ActionResultResource ResponseFactory(Exception? exception)
        {
            var response = exception switch
            {
                DateOutOfRangeException => new ActionResultResource(StatusCodes.Status400BadRequest,
                                                           new {Error = "Date number is out of range"}),
                _ => new ActionResultResource(StatusCodes.Status500InternalServerError,
                                     new {Error = "Date number is out of range"}),
            };
            return response;
        }
    }
}