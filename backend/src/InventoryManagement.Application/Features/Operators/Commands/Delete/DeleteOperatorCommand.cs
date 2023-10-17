using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.Operators.Commands.Delete
{
    public class DeleteOperatorCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteOperatorCommandHandler : IRequestHandler<DeleteOperatorCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOperatorCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteOperatorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Operators.FindAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }


            _context.Operators.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
