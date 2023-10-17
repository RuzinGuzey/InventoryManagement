using InventoryManagement.Application.Features.Communications.Commands.Create;
using InventoryManagement.Application.Features.Communications.Commands.Delete;
using InventoryManagement.Application.Features.Communications.Commands.Update;
using InventoryManagement.Application.Features.Communications.Queries.GetCommunication;
using InventoryManagement.Application.Features.Communications.Queries.GetCommunications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommunicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetCommunicationsQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetCommunicationQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCommunicationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCommunicationCommand command)
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
            await _mediator.Send(new DeleteCommunicationCommand() { Id = id });
            return Ok();
        }
    }
}
