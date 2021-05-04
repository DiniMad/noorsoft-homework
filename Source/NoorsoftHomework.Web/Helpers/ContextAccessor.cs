using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace NoorsoftHomework.Web.Helpers
{
    public static class ContextAccessor
    {
        public static IServiceCollection AddActionHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            return services;
        }
    }
}