using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;

namespace InventoryManagement.Application.Features.Debits.Queries.GetDebitQuery
{
    public class GetDebitQuery : IRequest<DebitDto>
    {
        public int Id { get; set; }
    }
    public class GetDebitQueryHandler : IRequestHandler<GetDebitQuery, DebitDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetDebitQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DebitDto> Handle(GetDebitQuery request, CancellationToken cancellationToken)
        {
            var debit = await _context.Debits.FindAsync(request.Id);
            if (debit == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<DebitDto>(debit);

        }
    }
}
