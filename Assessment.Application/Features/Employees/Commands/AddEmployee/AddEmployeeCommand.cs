using Assessment.Application.Responses;
using MediatR;

namespace Assessment.Application.Features.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommand : IRequest<ApiResponse<AddEmployeeCommandResponse>>
    {
        public string Name { get; set; }
        public string Title { get; set; }

        private string _departmentCategory;
        public string DepartmentCategory
        {
            get
            {
                return string.IsNullOrEmpty(_departmentCategory) ? "NONE" : _departmentCategory;
            }
            set
            {
                _departmentCategory = value.ToUpper();
            }
        }
    }
}

