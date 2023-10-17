using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;

namespace InventoryManagement.Application.Features.VehicleInventories.Queries.GetVehicleInventory
{
    public class GetVehicleInventoryQuery : IRequest<VehicleInventoryDto>
    {
        public int Id { get; set; }
    }
    public class GetVehicleInventoryQueryHandler : IRequestHandler<GetVehicleInventoryQuery, VehicleInventoryDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVehicleInventoryQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VehicleInventoryDto> Handle(GetVehicleInventoryQuery request, CancellationToken cancellationToken)
        {
            var vehicleInventory = await _context.VehicleInventories.FindAsync(request.Id);
            if (vehicleInventory == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<VehicleInventoryDto>(vehicleInventory);
        }
    }
}
