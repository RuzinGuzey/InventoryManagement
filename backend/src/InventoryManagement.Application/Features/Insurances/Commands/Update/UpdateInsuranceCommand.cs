using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;
using MediatR;

namespace InventoryManagement.Application.Features.Insurances.Commands.Update
{
    public class UpdateInsuranceCommand : IRequest
    {
        public int Id { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public int VehicleInventoryId { get; set; }
        public VehicleInventory VehicleInventory { get; set; } = null!;
        public string LicencePlate { get; set; } = string.Empty;
        public DateTime FirstInsuranceDate { get; set; }
        public DateTime AttachmentDate { get; set; }
        public DateTime DeadLineDate { get; set; }
        public float? InsuranceAmount { get; set; }
    }
    public class UpdateInsuranceCommandHandler : IRequest<UpdateInsuranceCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateInsuranceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateInsuranceCommand request, CancellationToken cancellationToken)
        {
            var insurance = await _context.Insurances.FindAsync(request.Id);
            if (insurance == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            insurance.InsuranceType = request.InsuranceType;
            insurance.LicencePlate = request.LicencePlate;
            insurance.FirstInsuranceDate = request.FirstInsuranceDate;
            insurance.AttachmentDate = request.AttachmentDate;
            insurance.DeadLineDate = request.DeadLineDate;
            insurance.InsuranceAmount = request.InsuranceAmount;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
