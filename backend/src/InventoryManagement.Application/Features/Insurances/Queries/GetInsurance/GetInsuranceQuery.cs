using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;

namespace InventoryManagement.Application.Features.Insurances.Queries.GetInsurance
{
    public class GetInsuranceQuery : IRequest<InsuranceDto>
    {
        public int Id { get; set; }
    }
    public class GetInsuranceQueryHandler : IRequestHandler<GetInsuranceQuery, InsuranceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetInsuranceQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<InsuranceDto> Handle(GetInsuranceQuery request, CancellationToken cancellationToken)
        {
            var insurance = await _context.Insurances.FindAsync(request.Id);
            if (insurance == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<InsuranceDto>(insurance);
        }

    }
}
