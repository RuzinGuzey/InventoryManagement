using AutoMapper;
using FluentValidation;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using MediatR;

namespace InventoryManagement.Application.Features.Debits.Command.Create
{
    public class CreateDebitCommand : IRequest<int>
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Note { get; set; }
    }
    public class CreateDebitCommandHandler : IRequestHandler<CreateDebitCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDebitCommand> _validator;
        public CreateDebitCommandHandler(IApplicationDbContext context, IMapper mapper, IValidator<CreateDebitCommand> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<int> Handle(CreateDebitCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var debit = new Debit
            {
                EmployeeId = request.EmployeeId,
                InventoryId = request.InventoryId,
                StartDate = request.StartDate,
                ReturnDate = request.ReturnDate,
                Note = request.Note,
            };
            _context.Debits.Add(debit);
            await _context.SaveChangesAsync(cancellationToken);
            return debit.Id;

        }
    }
}
