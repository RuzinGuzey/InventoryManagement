using FluentValidation;
using InventoryManagement.Application.Common.Interface;

namespace InventoryManagement.Application.Features.Employees.Command.Create
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateEmployeeCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(p => p.FirstName)
                .NotEmpty();
            RuleFor(p => p.SurName)
                .NotEmpty();
        }
    }
}
