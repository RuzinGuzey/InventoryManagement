using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Application.Dtos;
using MediatR;

namespace InventoryManagement.Application.Features.Communications.Queries.GetCommunication
{
    public class GetCommunicationQuery : IRequest<CommunicationDto>
    {
        public int Id { get; set; }
    }
    public class GetCommunicationQueryHandler : IRequestHandler<GetCommunicationQuery, CommunicationDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCommunicationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CommunicationDto> Handle(GetCommunicationQuery request, CancellationToken cancellationToken)
        {
            var communication = await _context.Communications.FindAsync(request.Id);
            if (communication == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            return _mapper.Map<CommunicationDto>(communication);
        }
    }

}

