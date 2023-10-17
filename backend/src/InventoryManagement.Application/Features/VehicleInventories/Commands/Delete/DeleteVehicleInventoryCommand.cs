using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.VehicleInventories.Commands.Delete
{
    public class DeleteVehicleInventoryCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteVehicleInventoryCommandHandler : IRequestHandler<DeleteVehicleInventoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteVehicleInventoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteVehicleInventoryCommand request, CancellationToken cancellationToken)
        {
            var vehicleInventory = await _context.VehicleInventories.FindAsync(request.Id);
            if (vehicleInventory == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.VehicleInventories.Remove(vehicleInventory);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
