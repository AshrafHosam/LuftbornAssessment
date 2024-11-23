using Assessment.Application.Contracts.Repos;
using Assessment.Application.Responses;
using MediatR;

namespace Assessment.Application.Features.Employees.Queries.GetEmployee
{
    internal class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, ApiResponse<GetEmployeeQueryResponse>>
    {
        private readonly IEmployeeRepo _employeeRepo;

        public GetEmployeeQueryHandler(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<ApiResponse<GetEmployeeQueryResponse>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepo.Get(request.Id);
            if (employee is null)
                return ApiResponse<GetEmployeeQueryResponse>.GetNotFoundApiResponse("Employee not found");

            return ApiResponse<GetEmployeeQueryResponse>
                .GetSuccessApiResponse(new GetEmployeeQueryResponse
                {
                    Id = employee.Id,
                    DepartmentCategory = employee.DepartmentCategoryId.ToString(),
                    Description = employee.Description,
                    Name = employee.Name,
                    Title = employee.Title
                });
        }
    }
}
