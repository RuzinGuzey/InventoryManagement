using InventoryManagement.Application.Features.VehicleInventories.Commands.Create;
using InventoryManagement.Application.Features.VehicleInventories.Commands.Delete;
using InventoryManagement.Application.Features.VehicleInventories.Commands.Update;
using InventoryManagement.Application.Features.VehicleInventories.Queries.GetVehicleInventories;
using InventoryManagement.Application.Features.VehicleInventories.Queries.GetVehicleInventory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class VehicleInventoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehicleInventoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetVehicleInventoriesQuery()));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _mediator.Send(new GetVehicleInventoryQuery() { Id = id }));
    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateVehicleInventoryCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateVehicleInventoryCommand command)
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
        await _mediator.Send(new DeleteVehicleInventoryCommand() { Id = id });
        return Ok();
    }
}