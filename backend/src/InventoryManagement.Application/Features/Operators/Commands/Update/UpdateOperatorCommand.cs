using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.Operators.Commands.Update
{
    public class UpdateOperatorCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class UpdateOperatorCommandHandler : IRequestHandler<UpdateOperatorCommand>
    {
        private readonly IApplicationDbContext _context;


        public UpdateOperatorCommandHandler(IApplicationDbContext context)
        {
            _context = context;

        }
        public async Task Handle(UpdateOperatorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Operators.FindAsync(request.Id);
            if (entity == null)
            {
                throw new Exception("Kayıt Yok!");
            }
            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

        }

    }
}
