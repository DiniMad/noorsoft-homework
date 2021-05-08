using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NoorsoftHomework.Web.Resources.Shared;

namespace NoorsoftHomework.Web.Filters
{
    public class ApiResponseResultFilter : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var objectResult = (context.Result as ObjectResult)!;
            var statusCode   = objectResult.StatusCode!.Value;
            objectResult.Value = context.ModelState.IsValid switch
            {
                true  => ApiResponse.Successful(statusCode, objectResult.Value),
                false => ApiResponse.Error(statusCode, ExtractErrorMessage(context))
            };

            await next();
        }

        private static string ExtractErrorMessage(ResultExecutingContext context)
        {
            var errorMessage = context.ModelState.Values
                                      .Where(v => v.Errors.Count > 0)
                                      .SelectMany(v => v.Errors)
                                      .Select(v => v.ErrorMessage)
                                      .First();
            return errorMessage;
        }
    }
}