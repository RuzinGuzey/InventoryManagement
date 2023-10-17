using InventoryManagement.Application.Features.Debits.Command.Create;
using InventoryManagement.Application.Features.Debits.Command.Delete;
using InventoryManagement.Application.Features.Debits.Command.Update;
using InventoryManagement.Application.Features.Debits.Queries.GetDebitQuery;
using InventoryManagement.Application.Features.Debits.Queries.GetDebitsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DebitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetDebitsQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetDebitQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDebitCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateDebitCommand command)
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
            await _mediator.Send(new DeleteDebitCommand() { Id = id });
            return Ok();
        }
    }
}

