using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using MediatR;

namespace InventoryManagement.Application.Features.VehicleInspections.Commands.Create
{
    public class CreateVehicleInspectionCommand : IRequest<int>
    {
        public string TechnicalServiceName { get; set; } = string.Empty;
        public int VehicleInventoryId { get; set; }
        public VehicleInventory VehicleInventory { get; set; } = null!;
        public string SasiNo { get; set; } = string.Empty;
        public string MotorNo { get; set; } = string.Empty;
        public string LicencePlate { get; set; } = string.Empty;
        public DateTime InspectionDate { get; set; }
        public string? InspectionResult { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
    public class CreateVehicleInspectionCommandHandler : IRequestHandler<CreateVehicleInspectionCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateVehicleInspectionCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateVehicleInspectionCommand request, CancellationToken cancellationToken)
        {
            var vehicleInspection = new VehicleInspection
            {
                TechnicalServiceName = request.TechnicalServiceName,
                SasiNo = request.SasiNo,
                MotorNo = request.MotorNo,
                LicencePlate = request.LicencePlate,
                InspectionDate = request.InspectionDate,
                InspectionResult = request.InspectionResult,
                ExpiryDate = request.ExpiryDate,
            };
            _context.VehicleInspections.Add(vehicleInspection);
            await _context.SaveChangesAsync(cancellationToken);
            return vehicleInspection.Id;

        }
    }
}
