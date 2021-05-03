using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoorsoftHomework.DataAccess;
using NoorsoftHomework.DataAccess.Interfaces;

namespace NoorsoftHomework.Web.Helpers
{
    public static class DataBaseContext
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>(serviceProvider =>
            {
                var configuration    = serviceProvider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("Default");
                var repository       = new EmployeeRepository(new SqlConnection(connectionString));
                return repository;
            });

            return services;
        }
    }
}