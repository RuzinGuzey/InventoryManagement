using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;
using MediatR;

namespace InventoryManagement.Application.Features.Insurances.Commands.Create
{
    public class CreateInsuranceCommand : IRequest<int>
    {
        public InsuranceType InsuranceType { get; set; }
        public int VehicleInventoryId { get; set; }
        public VehicleInventory VehicleInventory { get; set; } = null!;
        public string LicencePlate { get; set; } = string.Empty;
        public DateTime FirstInsuranceDate { get; set; }
        public DateTime AttachmentDate { get; set; }
        public DateTime DeadLineDate { get; set; }
        public float? InsuranceAmount { get; set; }
    }
    public class CreateInsuranceCommandHandler : IRequestHandler<CreateInsuranceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateInsuranceCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateInsuranceCommand request, CancellationToken cancellationToken)
        {
            var insurance = new Insurance
            {
                InsuranceType = request.InsuranceType,
                LicencePlate = request.LicencePlate,
                AttachmentDate = request.AttachmentDate,
                DeadLineDate = request.DeadLineDate,
                InsuranceAmount = request.InsuranceAmount,
            };

            _context.Insurances.Add(insurance);
            await _context.SaveChangesAsync(cancellationToken);
            return insurance.Id;
        }



    }
}
