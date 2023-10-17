using FluentValidation;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;
using MediatR;


namespace InventoryManagement.Application.Features.Communications.Commands.Create
{
    public class CreateCommunicationCommand : IRequest<int>
    {
        public ServiceType Service { get; set; }
        public int? EmployeeId { get; set; }
        public string ServiceNumber { get; set; } = string.Empty;
        public RateCardType Rate { get; set; }
        public int OperatorId { get; set; }
        public string? ProtocolName { get; set; }
        public float Price { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

    }
    public class CreateCommunicationCommandHandler : IRequestHandler<CreateCommunicationCommand, int>
    {
        private readonly IApplicationDbContext _context;

        private readonly IValidator<CreateCommunicationCommand> _validator;

        public CreateCommunicationCommandHandler(IApplicationDbContext context, IValidator<CreateCommunicationCommand> validator)
        {
            _context = context;

            _validator = validator;
        }
        public async Task<int> Handle(CreateCommunicationCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var communication = new Communication
            {
                Service = request.Service,
                EmployeeId = request.EmployeeId,
                ServiceNumber = request.ServiceNumber,
                Rate = request.Rate,
                OperatorId = request.OperatorId,
                ProtocolName = request.ProtocolName,
                Price = request.Price,
                StartTime = request.StartTime,
                EndTime = request.EndTime,


            };
            _context.Communications.Add(communication);
            await _context.SaveChangesAsync(cancellationToken);
            return communication.Id;
        }
    }
}
