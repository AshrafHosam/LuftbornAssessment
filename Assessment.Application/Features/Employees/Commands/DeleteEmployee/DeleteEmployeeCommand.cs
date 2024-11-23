using Assessment.Application.Responses;
using MediatR;

namespace Assessment.Application.Features.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<ApiResponse<DeleteEmployeeCommandResponse>>
    {
        public Guid Id { get; set; }
    }
}
