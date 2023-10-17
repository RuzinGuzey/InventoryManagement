using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.Insurances.Queries.GetInsurances
{
    public class GetInsurancesQuery : IRequest<List<InsuranceDto>>
    {
        public int Id { get; set; }
    }
    public class GetInsurancesQueryHandler : IRequestHandler<GetInsurancesQuery, List<InsuranceDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetInsurancesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<InsuranceDto>> Handle(GetInsurancesQuery request, CancellationToken cancellationToken)
        {
            var insurance = await _context.Insurances.ToListAsync(cancellationToken);
            return _mapper.Map<List<InsuranceDto>>(insurance);
        }

    }
}
