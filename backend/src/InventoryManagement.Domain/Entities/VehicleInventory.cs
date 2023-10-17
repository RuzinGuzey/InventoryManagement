using InventoryManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class VehicleInventory
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
