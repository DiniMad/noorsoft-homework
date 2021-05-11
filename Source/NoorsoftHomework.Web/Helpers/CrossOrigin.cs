using Microsoft.Extensions.DependencyInjection;

namespace NoorsoftHomework.Web.Helpers
{
    public static class CrossOrigin
    {
        public static IServiceCollection AddTheCors(this IServiceCollection services)
        {
            services.AddCors(options =>
                                 options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()
                                                                            .AllowAnyMethod()
                                                                            .AllowAnyHeader()));
            return services;
        }
    }
}