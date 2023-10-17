namespace InventoryManagement.Domain.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SeriNo { get; set; } = string.Empty;
        public int InventoryGroupId { get; set; }
        public InventoryGroup InventoryGroup { get; set; } = null!;
        public DateTime EntryDate { get; set; }
        public DateTime? GuaranteeStart { get; set; }
        public DateTime? GuaranteeEnd { get; set; }
        public double? Price { get; set; }
        //todo: whereabout statusu degisebilir
        public string WhereAbout { get; set; } = string.Empty;

    }
}
