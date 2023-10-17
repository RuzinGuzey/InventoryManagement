using FluentValidation;
using InventoryManagement.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.Debits.Command.Create
{
    public class CreateDebitCommandValidator : AbstractValidator<CreateDebitCommand>
    {
        private readonly IApplicationDbContext _dbContex;
        public CreateDebitCommandValidator(IApplicationDbContext dbContex)
        {
            _dbContex = dbContex;
            RuleFor(p => p.EmployeeId)
                .MustAsync(HasEmployee).WithMessage("Bu Personel burada calismiyor!");
            RuleFor(p => p.InventoryId)
                .MustAsync(HasInventory).WithMessage("Bu Operator kullanılmıyor!");
        }



        private async Task<bool> HasEmployee(int EmployeeId, CancellationToken cancellationToken)
        {
            return await _dbContex.Employees.AnyAsync(p => p.Id == EmployeeId, cancellationToken);
        }

        private async Task<bool> HasInventory(int InventoryId, CancellationToken cancellationToken)
        {
            return await _dbContex.Inventories.AnyAsync(p => p.Id == InventoryId, cancellationToken);
        }
    }
}
