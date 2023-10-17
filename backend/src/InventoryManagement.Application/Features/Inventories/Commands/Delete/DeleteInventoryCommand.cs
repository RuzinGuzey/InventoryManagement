using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.Inventories.Commands.Delete
{
    public class DeleteInventoryCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteInventoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _context.Inventories.FindAsync(request.Id);
            if (inventory == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
