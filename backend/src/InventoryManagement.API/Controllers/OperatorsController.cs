using InventoryManagement.Application.Features.Operators.Commands.Create;
using InventoryManagement.Application.Features.Operators.Commands.Delete;
using InventoryManagement.Application.Features.Operators.Commands.Update;
using InventoryManagement.Application.Features.Operators.Queries.GetOperator;
using InventoryManagement.Application.Features.Operators.Queries.GetOperators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OperatorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetOperatorsQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetOperatorQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOperatorCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateOperatorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOperatorCommand() { Id = id });
            return Ok();
        }
    }
}
