namespace InventoryManagement.Application.Dtos
{
    public class InventoryGroupDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
