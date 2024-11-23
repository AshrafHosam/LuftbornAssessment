using Assessment.Application.Contracts.Factories;
using Assessment.Application.Contracts.Repos;
using Assessment.Application.Responses;
using Assessment.Domain.Enums;
using MediatR;

namespace Assessment.Application.Features.Employees.Commands.UpdateEmployee
{
    internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ApiResponse<UpdateEmployeeCommandResponse>>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IStrategyFactory _strategyFactory;
        public UpdateEmployeeCommandHandler(IEmployeeRepo employeeRepo, IStrategyFactory strategyFactory)
        {
            _employeeRepo = employeeRepo;
            _strategyFactory = strategyFactory;
        }

        public async Task<ApiResponse<UpdateEmployeeCommandResponse>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var isEmployeeExist = await _employeeRepo.EmployeeExist(request.Id);
            if (!isEmployeeExist)
                return ApiResponse<UpdateEmployeeCommandResponse>.GetNotFoundApiResponse("Employee not found");

            Enum.TryParse(request.DepartmentCategory, out DepartmentCategoriesEnum departmentCtegoryId);

            var employee = _strategyFactory
                .GetEmployeeDescriptionStrategy((int)departmentCtegoryId)
                .Execute(request.Name, request.Title, request.DepartmentCategory);

            employee.Id = request.Id;

            _ = await _employeeRepo.Update(employee);

            return ApiResponse<UpdateEmployeeCommandResponse>.GetSuccessApiResponse(new());
        }
    }
}
