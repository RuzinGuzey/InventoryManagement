using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.Debits.Command.Delete
{
    public class DeleteDebitCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteDebitCommandHandler : IRequestHandler<DeleteDebitCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteDebitCommandHandler(IApplicationDbContext context)
        {
            _context = context;

        }
        public async Task Handle(DeleteDebitCommand request, CancellationToken cancellationToken)
        {
            var debit = await _context.Debits.FindAsync(request.Id);
            if (debit == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.Debits.Remove(debit);
            await _context.SaveChangesAsync(cancellationToken);



        }
    }
}

