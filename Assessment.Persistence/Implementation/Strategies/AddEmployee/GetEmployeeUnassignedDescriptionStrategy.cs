using Assessment.Application.Contracts.Strategies;
using Assessment.Domain.Entities;
using Assessment.Domain.Enums;

namespace Assessment.Persistence.Implementation.Strategies.AddEmployee
{
    internal class GetEmployeeUnassignedDescriptionStrategy : IGetEmployeeDescriptionStrategy
    {
        public Employee Execute(string name, string title, string departmentCategory)
        {
            Enum.TryParse(departmentCategory, out DepartmentCategoriesEnum departmentCtegoryId);
            return new Employee
            {
                Name = name,
                Title = title,
                DepartmentCategoryId = departmentCtegoryId,
                Description = "Unassigned"
            };
        }
    }
}
