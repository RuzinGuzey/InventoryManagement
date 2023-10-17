using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.InventoryGroups.Commands.Delete
{
    public class DeleteInventoryGroupCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteInventoryGroupCommandHandler : IRequestHandler<DeleteInventoryGroupCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteInventoryGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteInventoryGroupCommand request, CancellationToken cancellationToken)
        {
            var inventoryGroup = await _context.InventoryGroups.FindAsync(request.Id);
            if (inventoryGroup == null)
            {
                throw new Exception("Bu grup yok!");
            }
            _context.InventoryGroups.Remove(inventoryGroup);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
