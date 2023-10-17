using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.Maintenances.Queries.GetMaintenances
{
    public class GetMaintenancesQuery : IRequest<List<MaintenanceDto>>
    {
    }
    public class GetMaintenancesQueryHandler : IRequestHandler<GetMaintenancesQuery, List<MaintenanceDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetMaintenancesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MaintenanceDto>> Handle(GetMaintenancesQuery request, CancellationToken cancellationToken)
        {
            var maintenance = await _context.Maintenances.ToListAsync(cancellationToken);
            if (maintenance == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<List<MaintenanceDto>>(maintenance);
        }
    }
}
