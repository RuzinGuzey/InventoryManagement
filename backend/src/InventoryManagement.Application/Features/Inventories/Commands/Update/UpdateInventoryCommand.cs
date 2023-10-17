using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.Inventories.Commands.Update
{
    public class UpdateInventoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SeriNo { get; set; } = string.Empty;
        public int InventoryGroupId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? GuaranteeStart { get; set; }
        public DateTime? GuaranteeEnd { get; set; }
        public double? Price { get; set; }
        public string WhereAbout { get; set; } = string.Empty;

    }
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateInventoryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _context.Inventories.FindAsync(request.Id);
            if (inventory == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            inventory.Marka = request.Marka;
            inventory.Model = request.Model;
            inventory.SeriNo = request.SeriNo;
            inventory.EntryDate = request.EntryDate;
            inventory.InventoryGroupId = request.InventoryGroupId;
            inventory.GuaranteeStart = request.GuaranteeStart;
            inventory.GuaranteeEnd = request.GuaranteeEnd;
            inventory.Price = request.Price;
            inventory.WhereAbout = request.WhereAbout;
            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
