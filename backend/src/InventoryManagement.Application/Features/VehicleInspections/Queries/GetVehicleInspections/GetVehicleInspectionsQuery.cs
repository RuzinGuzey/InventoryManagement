using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.VehicleInspections.Queries.GetVehicleInspections
{
    public class GetVehicleInspectionsQuery : IRequest<List<VehicleInspectionDto>>
    {
    }
    public class GetVehicleInspectionsQueryHandler : IRequestHandler<GetVehicleInspectionsQuery, List<VehicleInspectionDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetVehicleInspectionsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<VehicleInspectionDto>> Handle(GetVehicleInspectionsQuery request, CancellationToken cancellationToken)
        {
            var vehicleInspection = await _context.VehicleInspections.ToListAsync(cancellationToken);
            return _mapper.Map<List<VehicleInspectionDto>>(vehicleInspection);
        }
    }
}
