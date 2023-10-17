using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.VehicleInspections.Commands.Update
{
    public class UpdateVehicleInspectionCommand : IRequest
    {
        public int Id { get; set; }
        public int VehicleInventoryId { get; set; }

        public string SasiNo { get; set; } = string.Empty;
        public string MotorNo { get; set; } = string.Empty;
        public string LicencePlate { get; set; } = string.Empty;
        public DateTime InspectionDate { get; set; }
        public string? InspectionResult { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
    public class UpdateVehicleInspectionCommandHandler : IRequestHandler<UpdateVehicleInspectionCommand>
    {
        private readonly IApplicationDbContext _context;


        public UpdateVehicleInspectionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateVehicleInspectionCommand request, CancellationToken cancellationToken)
        {
            var vehicleInspection = await _context.VehicleInspections.FindAsync(request.Id);
            if (vehicleInspection == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            vehicleInspection.SasiNo = request.SasiNo;
            vehicleInspection.MotorNo = request.MotorNo;
            vehicleInspection.LicencePlate = request.LicencePlate;
            vehicleInspection.InspectionDate = request.InspectionDate;
            vehicleInspection.InspectionResult = request.InspectionResult;
            vehicleInspection.ExpiryDate = request.ExpiryDate;
            await _context.SaveChangesAsync(cancellationToken);

        }



    }
}
