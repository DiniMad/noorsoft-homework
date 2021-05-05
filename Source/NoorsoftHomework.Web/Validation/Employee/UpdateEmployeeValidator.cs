using FluentValidation;
using NoorsoftHomework.Web.Resources.Employee;

namespace NoorsoftHomework.Web.Validation.Employee
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeResource>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(resource => resource.FirstName).Length(1, 255).NotNull();
            RuleFor(resource => resource.LastName).Length(1, 255).NotNull();
            RuleFor(resource => resource.BirthDate)
                .Matches(Constants.DateFormatRegex)
                .WithMessage(Constants.DateFormatErrorMessage)
                .NotNull();
            RuleFor(resource => resource.RecruitmentDate)
                .Matches(Constants.DateFormatRegex)
                .WithMessage(Constants.DateFormatErrorMessage)
                .NotNull();
        }
    }
}