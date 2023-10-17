using FluentValidation;
using InventoryManagement.Application.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Features.Communications.Commands.Update
{
    public class UpdateCommunicationCommandValidator : AbstractValidator<UpdateCommunicationCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateCommunicationCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(p => p.ServiceNumber)
                .NotEmpty();

            RuleFor(p => p.Rate)
                .IsInEnum();

            RuleFor(p => p.EmployeeId)
                .MustAsync(HasEmployee).WithMessage("Bu Personel burada calismiyor!");
            RuleFor(p => p.OperatorId)
                .MustAsync(HasOperator).WithMessage("Bu Operator kullanılmıyor!");
        }



        private async Task<bool> HasEmployee(int? EmployeeId, CancellationToken cancellationToken)
        {
            return await _dbContext.Employees.AnyAsync(p => p.Id == EmployeeId, cancellationToken);
        }
        private async Task<bool> HasOperator(int OperatorId, CancellationToken cancellationToken)
        {
            return await _dbContext.Operators.AnyAsync(p => p.Id == OperatorId, cancellationToken);
        }
    }
}
