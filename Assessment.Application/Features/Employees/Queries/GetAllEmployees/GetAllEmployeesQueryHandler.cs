using Assessment.Application.Contracts.Repos;
using Assessment.Application.Responses;
using MediatR;

namespace Assessment.Application.Features.Employees.Queries.GetAllEmployees
{
    internal class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, ApiResponse<List<GetAllEmployeesQueryResponse>>>
    {
        private readonly IEmployeeRepo _employeeRepo;

        public GetAllEmployeesQueryHandler(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<ApiResponse<List<GetAllEmployeesQueryResponse>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepo.GetAll();

            return ApiResponse<List<GetAllEmployeesQueryResponse>>
                .GetSuccessApiResponse(employees
                .Select(a => new GetAllEmployeesQueryResponse
                {
                    Id = a.Id,
                    DepartmentCategory = a.DepartmentCategoryId.ToString(),
                    Description = a.Description,
                    Name = a.Name,
                    Title = a.Title
                })
                .ToList());
        }
    }
}
