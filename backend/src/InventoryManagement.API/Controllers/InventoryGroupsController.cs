using InventoryManagement.Application.Features.InventoryGroups.Commands.Delete;
using InventoryManagement.Application.Features.InventoryGroups.Commands.Update;
using InventoryManagement.Application.Features.InventoryGroups.Queries.GetInventoryGroup;
using InventoryManagement.Application.Features.InventoryGroups.Queries.GetInventoryGroups;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryGroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryGroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetInventoryGroupsQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetInventoryGroupQuery() { Id = id }));
        }





        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateInventoryGroupCommand command)
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
            await _mediator.Send(new DeleteInventoryGroupCommand() { Id = id });
            return Ok();
        }
    }
}
