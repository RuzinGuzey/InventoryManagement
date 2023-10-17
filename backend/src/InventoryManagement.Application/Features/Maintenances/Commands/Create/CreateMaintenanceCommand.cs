using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;
using MediatR;

namespace InventoryManagement.Application.Features.Maintenances.Commands.Create
{
    public class CreateMaintenanceCommand : IRequest<int>
    {
        public string TechnicalServiceName { get; set; } = string.Empty;
        public Inventory? Inventory { get; set; }
        public VehicleInventory? Vehicle { get; set; }

        public ProcessType ProcessType { get; set; }
        public string OperationDescription { get; set; } = string.Empty;
        public float? Price { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime? DateDelivered { get; set; }
    }
    public class CreateMaintenanceCommandHandler : IRequestHandler<CreateMaintenanceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateMaintenanceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var maintenance = new Maintenance
            {
                TechnicalServiceName = request.TechnicalServiceName,
                Inventory = request.Inventory,
                Vehicle = request.Vehicle,
                ProcessType = request.ProcessType,
                OperationDescription = request.OperationDescription,
                Price = request.Price,
                IssuedOn = request.IssuedOn,
                DateDelivered = request.DateDelivered,
            };
            _context.Maintenances.Add(maintenance);
            await _context.SaveChangesAsync(cancellationToken);
            return maintenance.Id;
        }
    }
}
