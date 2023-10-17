using InventoryManagement.Application.Common.Interface;
using MediatR;

namespace InventoryManagement.Application.Features.Employees.Command.Update
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;

    }
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
            if (employee == null)
            {
                throw new Exception("Kayıt Bulunamadı!");

            }
            employee.FirstName = request.FirstName;
            employee.SurName = request.SurName;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
