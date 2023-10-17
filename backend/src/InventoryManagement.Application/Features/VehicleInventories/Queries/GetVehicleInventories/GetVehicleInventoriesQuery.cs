using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.VehicleInventories.Queries.GetVehicleInventories
{
    public class GetVehicleInventoriesQuery : IRequest<List<VehicleInventoryDto>>
    {
    }
    public class GetVehicleInventoriesQueryHandler : IRequestHandler<GetVehicleInventoriesQuery, List<VehicleInventoryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetVehicleInventoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<VehicleInventoryDto>> Handle(GetVehicleInventoriesQuery request, CancellationToken cancellationToken)
        {
            var vehicleInventories = await _context.VehicleInventories.ToListAsync(cancellationToken);
            return _mapper.Map<List<VehicleInventoryDto>>(vehicleInventories);
        }
    }
}
