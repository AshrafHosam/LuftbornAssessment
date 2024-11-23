using Assessment.Application.Contracts.Factories;
using Assessment.Application.Contracts.Repos;
using Assessment.Application.Responses;
using Assessment.Domain.Enums;
using MediatR;

namespace Assessment.Application.Features.Employees.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, ApiResponse<AddEmployeeCommandResponse>>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IStrategyFactory _strategyFactory;

        public AddEmployeeCommandHandler(IEmployeeRepo employeeRepo, IStrategyFactory strategyFactory)
        {
            _employeeRepo = employeeRepo;
            _strategyFactory = strategyFactory;
        }

        public async Task<ApiResponse<AddEmployeeCommandResponse>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            Enum.TryParse(request.DepartmentCategory, out DepartmentCategoriesEnum departmentCtegoryId);

            var employee = _strategyFactory
                .GetEmployeeDescriptionStrategy((int)departmentCtegoryId)
                .Execute(request.Name, request.Title, request.DepartmentCategory);

            var employeeId = await _employeeRepo.Add(employee);

            return ApiResponse<AddEmployeeCommandResponse>
                .GetSuccessApiResponse(
                new AddEmployeeCommandResponse
                {
                    Id = employeeId
                });

        }
    }
}
