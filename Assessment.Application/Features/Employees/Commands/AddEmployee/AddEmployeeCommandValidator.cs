using Assessment.Domain.Enums;
using FluentValidation;

namespace Assessment.Application.Features.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeCommandValidator()
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
