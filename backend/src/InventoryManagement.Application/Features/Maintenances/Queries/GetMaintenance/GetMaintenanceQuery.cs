using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;

namespace InventoryManagement.Application.Features.Maintenances.Queries.GetMaintenance
{
    public class GetMaintenanceQuery : IRequest<MaintenanceDto>
    {
        public int Id { get; set; }
    }
    public class GetMaintenanceQueryHandler : IRequestHandler<GetMaintenanceQuery, MaintenanceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetMaintenanceQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MaintenanceDto> Handle(GetMaintenanceQuery request, CancellationToken cancellationToken)
        {
            var maintenance = await _context.Maintenances.FindAsync(request.Id);
            if (maintenance == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<MaintenanceDto>(maintenance);

        }
    }
}
