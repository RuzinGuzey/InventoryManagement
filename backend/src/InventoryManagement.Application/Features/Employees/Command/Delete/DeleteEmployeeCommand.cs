using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.Employees.Command.Delete
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteEmployeeCommandHandler : IRequest<DeleteEmployeeCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            if (employee == null)
            {
                throw new Exception("Kayıt Bulunamadı!");

            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
