using InventoryManagement.Application.Common.Interface;
using MediatR;


namespace InventoryManagement.Application.Features.Communications.Commands.Delete
{
    public class DeleteCommunicationCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteCommunicationCommandHandler : IRequestHandler<DeleteCommunicationCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCommunicationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteCommunicationCommand request, CancellationToken cancellationToken)
        {
            var communication = await _context.Communications.FindAsync(request.Id);
            if (communication == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.Communications.Remove(communication);
            await _context.SaveChangesAsync(cancellationToken);
        }


    }
}
