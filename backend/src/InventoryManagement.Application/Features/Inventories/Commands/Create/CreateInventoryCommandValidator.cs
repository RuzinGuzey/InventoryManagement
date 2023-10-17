using FluentValidation;
using InventoryManagement.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.Inventories.Commands.Create
{
    public class CreateInventoryCommandValidator : AbstractValidator<CreateInventoryCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateInventoryCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(p => p.Marka)
                .NotEmpty();

            RuleFor(p => p.Model)
                .NotEmpty();

            RuleFor(p => p.InventoryGroupId)
                .MustAsync(HasInventoryGroup).WithMessage("Envanter grubu bulunamadı.");
        }

        private async Task<bool> HasInventoryGroup(int inventoryGroupId, CancellationToken cancellationToken)
        {
            return await _dbContext.InventoryGroups.AnyAsync(p => p.Id == inventoryGroupId, cancellationToken);
        }
    }
}
