using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;

namespace InventoryManagement.Application.Features.InventoryGroups.Queries.GetInventoryGroup
{
    public class GetInventoryGroupQuery : IRequest<InventoryGroupDto>
    {
        public int Id { get; set; }
    }
    public class GetInventoryGroupQueryHandler : IRequestHandler<GetInventoryGroupQuery, InventoryGroupDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetInventoryGroupQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<InventoryGroupDto> Handle(GetInventoryGroupQuery request, CancellationToken cancellationToken)
        {
            var inventoryGroup = await _context.InventoryGroups.FindAsync(request.Id);
            if (inventoryGroup == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<InventoryGroupDto>(inventoryGroup);
        }
    }
}
