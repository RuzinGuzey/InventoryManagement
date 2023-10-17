using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.InventoryGroups.Queries.GetInventoryGroups
{
    public class GetInventoryGroupsQuery : IRequest<List<InventoryGroupDto>>
    {
    }
    public class GetInventoryGroupsQueryHandler : IRequestHandler<GetInventoryGroupsQuery, List<InventoryGroupDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetInventoryGroupsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<InventoryGroupDto>> Handle(GetInventoryGroupsQuery request, CancellationToken cancellationToken)
        {
            var inventoryGroup = await _context.InventoryGroups.ToListAsync(cancellationToken);
            return _mapper.Map<List<InventoryGroupDto>>(inventoryGroup);
        }

    }
}
