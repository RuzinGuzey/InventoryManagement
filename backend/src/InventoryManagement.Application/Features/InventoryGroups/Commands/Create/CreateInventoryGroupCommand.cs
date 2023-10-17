using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using MediatR;

namespace InventoryManagement.Application.Features.InventoryGroups.Commands.Create
{
    public class CreateInventoryGroupCommand : IRequest<int>
    {
        public int? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class CreateInventoryGroupCommandHandler : IRequestHandler<CreateInventoryGroupCommand, int>
    {
        private readonly IApplicationDbContext _context;


        public CreateInventoryGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateInventoryGroupCommand request, CancellationToken cancellationToken)
        {
            var inventoryGroup = new InventoryGroup
            {
                ParentId = request.ParentId,
                Name = request.Name,

            };
            _context.InventoryGroups.Add(inventoryGroup);
            await _context.SaveChangesAsync(cancellationToken);
            return inventoryGroup.Id;
        }

    }
}
