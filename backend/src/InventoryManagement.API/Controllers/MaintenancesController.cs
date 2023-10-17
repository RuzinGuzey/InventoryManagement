using InventoryManagement.Application.Features.Maintenances.Commands.Create;
using InventoryManagement.Application.Features.Maintenances.Commands.Delete;
using InventoryManagement.Application.Features.Maintenances.Commands.Update;
using InventoryManagement.Application.Features.Maintenances.Queries.GetMaintenance;
using InventoryManagement.Application.Features.Maintenances.Queries.GetMaintenances;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenancesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaintenancesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetMaintenancesQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetMaintenanceQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMaintenanceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateMaintenanceCommand command)
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
            await _mediator.Send(new DeleteMaintenanceCommand() { Id = id });
            return Ok();
        }
    }
}

