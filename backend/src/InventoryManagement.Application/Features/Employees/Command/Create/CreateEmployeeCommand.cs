using AutoMapper;
using FluentValidation;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using MediatR;

namespace InventoryManagement.Application.Features.Employees.Command.Create
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;

    }
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateEmployeeCommand> _validator;
        public CreateEmployeeCommandHandler(IApplicationDbContext context, IMapper mapper, IValidator<CreateEmployeeCommand> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var employee = new Employee
            {
                FirstName = request.FirstName,
                SurName = request.SurName,

            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            return employee.Id;

        }
    }
}
