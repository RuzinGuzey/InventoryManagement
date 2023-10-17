using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.Communications.Queries.GetCommunications
{
    public class GetCommunicationsQuery : IRequest<List<CommunicationDto>>
    {
    }
    public class GetCommunicationsQueryHandler : IRequestHandler<GetCommunicationsQuery, List<CommunicationDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCommunicationsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CommunicationDto>> Handle(GetCommunicationsQuery request, CancellationToken cancellationToken)
        {
            var communication = await _context.Communications.ToListAsync(cancellationToken);
            return _mapper.Map<List<CommunicationDto>>(communication);
        }
    }
}
