using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.Insurances.Commands.Delete
{
    public class DeleteInsuranceCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteInsuranceCommandHandler : IRequestHandler<DeleteInsuranceCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteInsuranceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteInsuranceCommand request, CancellationToken cancellationToken)
        {
            var insurance = await _context.Insurances.FindAsync(request.Id);
            if (insurance == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            _context.Insurances.Remove(insurance);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
