using Assessment.Application.Features.Employees.Commands.AddEmployee;
using Assessment.Domain.Entities;

namespace Assessment.Application.Contracts.Strategies
{
    public interface IGetEmployeeDescriptionStrategy
    {
        Employee Execute(string name, string title, string departmentCategory);
    }
}
