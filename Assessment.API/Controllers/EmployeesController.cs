using Assessment.Application.Features.Employees.Commands.AddEmployee;
using Assessment.Application.Features.Employees.Commands.DeleteEmployee;
using Assessment.Application.Features.Employees.Commands.UpdateEmployee;
using Assessment.Application.Features.Employees.Queries.GetAllEmployees;
using Assessment.Application.Features.Employees.Queries.GetEmployee;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.API.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddEmployeeCommandResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<AddEmployeeCommandResponse>> AddEmployee(AddEmployeeCommand command)
        {
            var result = await _mediator.Send(command);

            return GetApiResponse(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(DeleteEmployeeCommandResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<DeleteEmployeeCommandResponse>> DeleteEmployee(Guid id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand
            {
                Id = id
            });

            return GetApiResponse(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UpdateEmployeeCommandResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<UpdateEmployeeCommandResponse>> UpdateEmployee(UpdateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);

            return GetApiResponse(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllEmployeesQueryResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<GetAllEmployeesQueryResponse>>> GetAllEmployees()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());

            return GetApiResponse(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetEmployeeQueryResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetEmployeeQueryResponse>> GetEmployee(Guid id)
        {
            var result = await _mediator.Send(new GetEmployeeQuery
            {
                Id = id
            });

            return GetApiResponse(result);
        }
    }
}
