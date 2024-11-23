using Assessment.Application.Contracts.Repos;
using Assessment.Application.Responses;
using MediatR;

namespace Assessment.Application.Features.Employees.Commands.DeleteEmployee
{
    internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ApiResponse<DeleteEmployeeCommandResponse>>
    {
        private readonly IEmployeeRepo _employeeRepo;

        public DeleteEmployeeCommandHandler(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<ApiResponse<DeleteEmployeeCommandResponse>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var isEmployeeExist = await _employeeRepo.EmployeeExist(request.Id);
            if (!isEmployeeExist)
                return ApiResponse<DeleteEmployeeCommandResponse>.GetNotFoundApiResponse("Employee not found");

            _ = await _employeeRepo.Delete(request.Id);

            return ApiResponse<DeleteEmployeeCommandResponse>.GetSuccessApiResponse(new());
        }
    }
}
