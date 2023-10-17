using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Entities
{
    public class Communication
    {
        public int Id { get; set; }
        public ServiceType Service { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public string ServiceNumber { get; set; } = string.Empty;
        public RateCardType Rate { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator { get; set; } = null!;
        public string? ProtocolName { get; set; }
        public float Price { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }



    }
}
