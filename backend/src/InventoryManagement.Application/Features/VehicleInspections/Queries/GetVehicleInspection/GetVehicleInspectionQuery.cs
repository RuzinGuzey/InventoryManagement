using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;

namespace InventoryManagement.Application.Features.VehicleInspections.Queries.GetVehicleInspection
{
    public class GetVehicleInspectionQuery : IRequest<VehicleInspectionDto>
    {
        public int Id { get; set; }
    }
    public class GetVehicleInspectionQueryHandler : IRequestHandler<GetVehicleInspectionQuery, VehicleInspectionDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetVehicleInspectionQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VehicleInspectionDto> Handle(GetVehicleInspectionQuery request, CancellationToken cancellationToken)
        {
            var vehicleInspection = await _context.VehicleInspections.FindAsync(request.Id);
            if (vehicleInspection == null)
            {
                throw new Exception("Kayıt BUlunamadı!");
            }
            return _mapper.Map<VehicleInspectionDto>(vehicleInspection);
        }

    }
}
