﻿using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Application.Dtos
{
    public class MaintenanceDto
    {
        public int Id { get; set; }
        public string TechnicalServiceName { get; set; } = string.Empty;
        public Inventory? Inventory { get; set; }
        public VehicleInventory? Vehicle { get; set; }

        public ProcessType ProcessType { get; set; }
        public string OperationDescription { get; set; } = string.Empty;
        public float? Price { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime? DateDelivered { get; set; }
    }
}
