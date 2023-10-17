using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;

namespace InventoryManagement.Application.Features.Operators.Queries.GetOperator
{
    public class GetOperatorQuery : IRequest<OperatorDto>
    {
        public int Id { get; set; }
    }
    public class GetOperatorHandler : IRequestHandler<GetOperatorQuery, OperatorDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOperatorHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OperatorDto> Handle(GetOperatorQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Operators.FindAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<OperatorDto>(entity);
        }



    }
}
