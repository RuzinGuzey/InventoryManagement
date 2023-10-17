using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;

namespace InventoryManagement.Application.Features.Inventories.Queries.GetInventory
{
    public class GetInventoryQuery : IRequest<InventoryDto>
    {
        public int Id { get; set; }
    }
    public class GetInventoryQueryHandler : IRequestHandler<GetInventoryQuery, InventoryDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetInventoryQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<InventoryDto> Handle(GetInventoryQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _context.Inventories.FindAsync(request.Id);
            if (inventory == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<InventoryDto>(inventory);
        }
    }
}