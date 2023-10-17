using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities
{
    public class InventoryGroup
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public InventoryGroup? Parent { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
