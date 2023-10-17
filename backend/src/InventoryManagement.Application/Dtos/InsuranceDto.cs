using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Application.Dtos
{
    public class InsuranceDto
    {
        public int Id { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public int VehicleInventoryId { get; set; }

        public string LicencePlate { get; set; } = string.Empty;
        public DateTime FirstInsuranceDate { get; set; }
        public DateTime AttachmentDate { get; set; }
        public DateTime DeadLineDate { get; set; }
        public float? InsuranceAmount { get; set; }
    }
}
