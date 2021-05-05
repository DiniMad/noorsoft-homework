using FluentValidation;
using NoorsoftHomework.Web.Resources.Shared;

namespace NoorsoftHomework.Web.Validation.Employee
{
    public class SortingAndPagingValidator : AbstractValidator<SortingAndPagingResource>
    {
        public SortingAndPagingValidator()
        {
            RuleFor(resource => resource.SortColumn).IsInEnum();
            RuleFor(resource => resource.SortDirection).IsInEnum();
            RuleFor(resource => resource.PageSize).GreaterThan(0).LessThanOrEqualTo(20);
            RuleFor(resource => resource.PageNumber).GreaterThan(0);
        }
    }
}