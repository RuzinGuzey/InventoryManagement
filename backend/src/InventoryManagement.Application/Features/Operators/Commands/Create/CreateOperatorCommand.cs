using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using MediatR;

namespace InventoryManagement.Application.Features.Operators.Commands.Create
{
    public class CreateOperatorCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
    }
    public class CreateOperatorCommandHandler : IRequestHandler<CreateOperatorCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public CreateOperatorCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<int> Handle(CreateOperatorCommand request, CancellationToken cancellationToken)
        {
            var entity = new Operator
            {
                Name = request.Name,
            };
            _context.Operators.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;

        }

    }
}
