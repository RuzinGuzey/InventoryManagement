using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Enums;
using MediatR;

namespace InventoryManagement.Application.Features.VehicleInventories.Commands.Update
{
    public class UpdateVehicleInventoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public short ModelYear { get; set; }
        public string? SasiNo { get; set; }
        public string? MotorNo { get; set; }
        public string LicencePlate { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; }
        public SegmentType? Segment { get; set; }
    }
    public class UpdateVehicleInventoryCommandHandler : IRequestHandler<UpdateVehicleInventoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateVehicleInventoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateVehicleInventoryCommand request, CancellationToken cancellationToken)
        {
            var vehicleInventory = await _context.VehicleInventories.FindAsync(request.Id);
            if (vehicleInventory == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            vehicleInventory.Marka = request.Marka;
            vehicleInventory.Model = request.Model;
            vehicleInventory.ModelYear = request.ModelYear;
            vehicleInventory.SasiNo = request.SasiNo;
            vehicleInventory.MotorNo = request.MotorNo;
            vehicleInventory.LicencePlate = request.LicencePlate;
            vehicleInventory.EntryDate = request.EntryDate;
            vehicleInventory.Segment = request.Segment;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
