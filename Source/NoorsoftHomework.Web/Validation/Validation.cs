using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using NoorsoftHomework.Web.Validation.Employee;

namespace NoorsoftHomework.Web.Validation
{
    public static class Validation
    {
        public static IMvcBuilder AddValidation(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddFluentValidation(configuration =>
            {
                configuration.RegisterValidatorsFromAssemblyContaining<SortingAndPagingValidator>(lifetime:
                    ServiceLifetime
                        .Singleton);
                configuration.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });

            return mvcBuilder;
        }
    }
}