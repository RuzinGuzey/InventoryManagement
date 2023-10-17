namespace InventoryManagement.Domain.Entities
{
    public class VehicleInspection
    {
        public int Id { get; set; }
        public string TechnicalServiceName { get; set; } = string.Empty;
        public int VehicleInventoryId { get; set; }
        public VehicleInventory VehicleInventory { get; set; } = null!;
        public string SasiNo { get; set; } = string.Empty;
        public string MotorNo { get; set; } = string.Empty;
        public string LicencePlate { get; set; } = string.Empty;
        public DateTime InspectionDate { get; set; }
        public string? InspectionResult { get; set; }
        public DateTime ExpiryDate { get; set; }

        //Belge Eklemesi ????



    }
}
