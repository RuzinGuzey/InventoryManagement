using FluentValidation;
using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.Debits.Command.Update
{
    public class UpdateDebitCommand : IRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public int InventoryId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Note { get; set; }

    }
    public class UpdateDebitCommandHandler : IRequestHandler<UpdateDebitCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IValidator<UpdateDebitCommand> _validator;
        public UpdateDebitCommandHandler(IApplicationDbContext context, IValidator<UpdateDebitCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task Handle(UpdateDebitCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var debit = await _context.Debits.FindAsync(request.Id);
            if (debit == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            debit.InventoryId = request.InventoryId;
            debit.EmployeeId = request.EmployeeId;
            debit.StartDate = request.StartDate;
            debit.ReturnDate = request.ReturnDate;
            debit.Note = request.Note;
            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
