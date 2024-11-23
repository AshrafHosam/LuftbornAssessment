using Assessment.Application.Responses;
using MediatR;

namespace Assessment.Application.Features.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<ApiResponse<UpdateEmployeeCommandResponse>>
    {
        public Guid Id { get; set; }
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
