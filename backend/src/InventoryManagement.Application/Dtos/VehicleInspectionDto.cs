namespace InventoryManagement.Application.Dtos
{
    public class VehicleInspectionDto
    {
        public int Id { get; set; }
        public string TechnicalServiceName { get; set; } = string.Empty;
        public int VehicleInventoryId { get; set; }

        public string SasiNo { get; set; } = string.Empty;
        public string MotorNo { get; set; } = string.Empty;
        public string LicencePlate { get; set; } = string.Empty;
        public DateTime InspectionDate { get; set; }
        public string? InspectionResult { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
