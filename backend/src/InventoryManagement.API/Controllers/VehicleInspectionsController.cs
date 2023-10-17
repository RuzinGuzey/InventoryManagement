using InventoryManagement.Application.Features.VehicleInspections.Commands.Create;
using InventoryManagement.Application.Features.VehicleInspections.Commands.Delete;
using InventoryManagement.Application.Features.VehicleInspections.Commands.Update;
using InventoryManagement.Application.Features.VehicleInspections.Queries.GetVehicleInspection;
using InventoryManagement.Application.Features.VehicleInspections.Queries.GetVehicleInspections;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleInspectionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleInspectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetVehicleInspectionsQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetVehicleInspectionQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateVehicleInspectionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateVehicleInspectionCommand command)
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
            await _mediator.Send(new DeleteVehicleInspectionCommand() { Id = id });
            return Ok();
        }
    }
}

