using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Application.Dtos
{
    public class VehicleInventoryDto
    {
        public int Id { get; set; }
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public short ModelYear { get; set; }
        public string? SasiNo { get; set; }
        public string? MotorNo { get; set; }
        public string LicencePlate { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; }
        public SegmentType? Segment { get; set; }
    }
}
