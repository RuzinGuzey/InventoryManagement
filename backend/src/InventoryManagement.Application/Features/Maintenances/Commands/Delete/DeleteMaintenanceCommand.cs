using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.Maintenances.Commands.Delete
{
    public class DeleteMaintenanceCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteMaintenanceCommandHandler : IRequestHandler<DeleteMaintenanceCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteMaintenanceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var maintenance = await _context.Maintenances.FindAsync(request.Id);
            if (maintenance == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.Maintenances.Remove(maintenance);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
