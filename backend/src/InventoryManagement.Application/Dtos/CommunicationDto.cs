using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Application.Dtos
{
    public class CommunicationDto
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
}
