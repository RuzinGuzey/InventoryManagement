using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.Operators.Queries.GetOperators
{
    public class GetOperatorsQuery : IRequest<List<OperatorDto>>
    {
    }
    public class GetOperatorsHandler : IRequestHandler<GetOperatorsQuery, List<OperatorDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOperatorsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<OperatorDto>> Handle(GetOperatorsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Operators.ToListAsync(cancellationToken);
            return _mapper.Map<List<OperatorDto>>(entity);
        }
    }
}
