using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.Debits.Queries.GetDebitsQuery
{
    public class GetDebitsQuery : IRequest<List<DebitDto>>
    {

    }
    public class GetDebitsQueryHandler : IRequestHandler<GetDebitsQuery, List<DebitDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetDebitsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DebitDto>> Handle(GetDebitsQuery request, CancellationToken cancellationToken)
        {
            var debit = await _context.Debits.ToListAsync(cancellationToken);
            return _mapper.Map<List<DebitDto>>(debit);

        }
    }
}
