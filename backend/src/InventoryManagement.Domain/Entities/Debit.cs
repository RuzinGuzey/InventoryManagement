﻿namespace InventoryManagement.Domain.Entities
{
    public class Debit
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Note { get; set; }

    }
}
