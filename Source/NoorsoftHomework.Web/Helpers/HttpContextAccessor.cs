using Microsoft.AspNetCore.Http;

namespace NoorsoftHomework.Web.Helpers
{
    public static class HttpContextAccessor
    {
        public static string GetUrl(this HttpContext? httpContext)
        {
            var httpRequest = httpContext!.Request;
            var url         = $"{httpRequest.Scheme}://{httpRequest.Host.Value}{httpRequest.Path.Value!.TrimEnd('/')}";
            return url;
        }
    }
}