using FluentValidation;
using InventoryManagement.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.Debits.Command.Update
{
    public class UpdateDebitCommandValidator : AbstractValidator<UpdateDebitCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateDebitCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(p => p.EmployeeId)
                .MustAsync(HasEmployee).WithMessage("Bu Personel burada calismiyor!");
            RuleFor(p => p.InventoryId)
                .MustAsync(HasInventory).WithMessage("Bu Operator kullanılmıyor!");
        }

        private async Task<bool> HasEmployee(int EmployeeId, CancellationToken cancellationToken)
        {
            return await _dbContext.Employees.AnyAsync(p => p.Id == EmployeeId, cancellationToken);
        }

        private async Task<bool> HasInventory(int InventoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.Inventories.AnyAsync(p => p.Id == InventoryId, cancellationToken);
        }
    }
}

