using AutoMapper;
using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.InventoryGroups.Commands.Update
{
    public class UpdateInventoryGroupCommand : IRequest
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class UpdateInventoryGroupCommandHandler : IRequestHandler<UpdateInventoryGroupCommand>
    {
        private readonly IApplicationDbContext _context;


        public UpdateInventoryGroupCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;

        }
        public async Task Handle(UpdateInventoryGroupCommand request, CancellationToken cancellationToken)
        {
            var inventoryGroup = await _context.InventoryGroups.FindAsync(request.Id);
            if (inventoryGroup == null)
            {
                throw new Exception("Bu grup yok!");
            }
            inventoryGroup.ParentId = request.ParentId;
            inventoryGroup.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

        }

    }
}
