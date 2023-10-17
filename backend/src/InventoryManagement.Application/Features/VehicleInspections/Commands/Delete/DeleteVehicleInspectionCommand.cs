using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.VehicleInspections.Commands.Delete
{
    public class DeleteVehicleInspectionCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteVehicleInspectionCommandHandler : IRequestHandler<DeleteVehicleInspectionCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteVehicleInspectionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteVehicleInspectionCommand request, CancellationToken cancellationToken)
        {
            var vehicleInspection = await _context.VehicleInspections.FindAsync(request.Id);
            if (vehicleInspection == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.VehicleInspections.Remove(vehicleInspection);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
