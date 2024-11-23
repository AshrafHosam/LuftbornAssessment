using Assessment.Application.Responses;
using MediatR;

namespace Assessment.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<ApiResponse<List<GetAllEmployeesQueryResponse>>>
    {
    }
}
