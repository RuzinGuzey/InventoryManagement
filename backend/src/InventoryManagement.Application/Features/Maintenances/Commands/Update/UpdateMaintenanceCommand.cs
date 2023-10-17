using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;
using MediatR;

namespace InventoryManagement.Application.Features.Maintenances.Commands.Update
{
    public class UpdateMaintenanceCommand : IRequest
    {
        public int Id { get; set; }
        public string TechnicalServiceName { get; set; } = string.Empty;
        public Inventory? Inventory { get; set; }
        public VehicleInventory? Vehicle { get; set; }

        public ProcessType ProcessType { get; set; }
        public string OperationDescription { get; set; } = string.Empty;
        public float? Price { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime? DateDelivered { get; set; }

    }
    public class UpdateMaintenanceCommandHandler : IRequestHandler<UpdateMaintenanceCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateMaintenanceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var maintenance = await _context.Maintenances.FindAsync(request.Id);
            if (maintenance == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            maintenance.TechnicalServiceName = request.TechnicalServiceName;
            maintenance.Inventory = request.Inventory;
            maintenance.Vehicle = request.Vehicle;
            maintenance.ProcessType = request.ProcessType;
            maintenance.OperationDescription = request.OperationDescription;
            maintenance.Price = request.Price;
            maintenance.IssuedOn = request.IssuedOn;
            maintenance.DateDelivered = request.DateDelivered;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }


}
