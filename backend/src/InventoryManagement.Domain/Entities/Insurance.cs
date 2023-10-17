using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Entities
{
    public class Insurance
    {
        public int Id { get; set; }
        public int VehicleInventoryId { get; set; }
        public VehicleInventory VehicleInventory { get; set; } = null!;
        public InsuranceType InsuranceType { get; set; }
        public string LicencePlate { get; set; } = string.Empty;
        public DateTime FirstInsuranceDate { get; set; }
        public DateTime AttachmentDate { get; set; }
        public DateTime DeadLineDate { get; set; }
        public float? InsuranceAmount { get; set; }

        //Belge Eklemesi???
    }
}
