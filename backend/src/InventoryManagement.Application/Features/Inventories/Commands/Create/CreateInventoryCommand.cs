using FluentValidation;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using MediatR;

namespace InventoryManagement.Application.Features.Inventories.Commands.Create
{
    public class CreateInventoryCommand : IRequest<int>
    {
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

    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IValidator<CreateInventoryCommand> _validator;

        public CreateInventoryCommandHandler(IApplicationDbContext context, IValidator<CreateInventoryCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<int> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var inventory = new Inventory
            {
                Marka = request.Marka,
                Model = request.Model,
                SeriNo = request.SeriNo,
                EntryDate = request.EntryDate,
                InventoryGroupId = request.InventoryGroupId,
                GuaranteeStart = request.GuaranteeStart,
                GuaranteeEnd = request.GuaranteeEnd,
                Price = request.Price,
                WhereAbout = request.WhereAbout,
            };
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync(cancellationToken);
            return inventory.Id;
        }
    }
}
