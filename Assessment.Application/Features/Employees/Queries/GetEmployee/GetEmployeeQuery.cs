using Assessment.Application.Responses;
using MediatR;

namespace Assessment.Application.Features.Employees.Queries.GetEmployee
{
    public class GetEmployeeQuery : IRequest<ApiResponse<GetEmployeeQueryResponse>>
    {
        public Guid Id { get; set; }
    }
}
