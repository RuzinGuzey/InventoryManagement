using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;
using MediatR;

namespace InventoryManagement.Application.Features.VehicleInventories.Commands.Create
{
    public class CreateVehicleInventoryCommand : IRequest<int>
    {
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public short ModelYear { get; set; }
        public string? SasiNo { get; set; }
        public string? MotorNo { get; set; }
        public string LicencePlate { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; }
        public SegmentType? Segment { get; set; }
    }
    public class CreateVehicleInventoryCommandHandler : IRequestHandler<CreateVehicleInventoryCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateVehicleInventoryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateVehicleInventoryCommand request, CancellationToken cancellationToken)
        {
            var vehicleInventory = new VehicleInventory
            {
                Marka = request.Marka,
                Model = request.Model,
                ModelYear = request.ModelYear,
                SasiNo = request.SasiNo,
                MotorNo = request.MotorNo,
                LicencePlate = request.LicencePlate,
                EntryDate = request.EntryDate,
                Segment = request.Segment,
            };
            _context.VehicleInventories.Add(vehicleInventory);
            await _context.SaveChangesAsync(cancellationToken);
            return vehicleInventory.Id;
        }
    }
}
