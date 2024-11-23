using Assessment.Domain.Enums;
using FluentValidation;

namespace Assessment.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(55);

            RuleFor(a => a.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(75);

            RuleFor(a => a.DepartmentCategory)
                .NotNull()
                .NotEmpty()
                .Must(IsInEnum);
        }
        private static bool IsInEnum(string departmentCategory)
           => Enum.TryParse(departmentCategory, out DepartmentCategoriesEnum departmentCtegoryId);
    }
}
