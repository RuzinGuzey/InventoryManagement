using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.Inventories.Queries.GetInventories
{
    public class GetInventoriesQuery : IRequest<List<InventoryDto>>
    {
    }
    public class GetInventoriesQueryHandler : IRequestHandler<GetInventoriesQuery, List<InventoryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetInventoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<InventoryDto>> Handle(GetInventoriesQuery request, CancellationToken cancellationToken)
        {
            var inventories = await _context.Inventories.ToListAsync(cancellationToken);
            return _mapper.Map<List<InventoryDto>>(inventories);
        }
    }

}
