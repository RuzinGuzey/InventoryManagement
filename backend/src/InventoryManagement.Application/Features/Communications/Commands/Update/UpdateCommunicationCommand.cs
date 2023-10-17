using FluentValidation;
using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Enums;
using MediatR;

namespace InventoryManagement.Application.Features.Communications.Commands.Update
{
    public class UpdateCommunicationCommand : IRequest
    {
        public int Id { get; set; }
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
    public class UpdateCommunicationCommandHandler : IRequestHandler<UpdateCommunicationCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IValidator<UpdateCommunicationCommand> _validator;

        public UpdateCommunicationCommandHandler(IApplicationDbContext context, IValidator<UpdateCommunicationCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task Handle(UpdateCommunicationCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var communication = await _context.Communications.FindAsync(request.Id);
            if (communication == null)
            {
                throw new Exception("Kayıt Bulunamadı!");
            }
            communication.Service = request.Service;
            communication.EmployeeId = request.EmployeeId;
            communication.ServiceNumber = request.ServiceNumber;
            communication.Rate = request.Rate;
            communication.OperatorId = request.OperatorId;
            communication.ProtocolName = request.ProtocolName;
            communication.Price = request.Price;
            communication.StartTime = request.StartTime;
            communication.EndTime = request.EndTime;


            await _context.SaveChangesAsync(cancellationToken);
        }


    }
}