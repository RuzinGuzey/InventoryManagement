using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Application.Common.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<Inventory> Inventories { get; }
        DbSet<InventoryGroup> InventoryGroups { get; }
        DbSet<VehicleInventory> VehicleInventories { get; }
        DbSet<Communication> Communications { get; }
        DbSet<Insurance> Insurances { get; }
        DbSet<Maintenance> Maintenances { get; }
        DbSet<VehicleInspection> VehicleInspections { get; }
        DbSet<Operator> Operators { get; }
        DbSet<Employee> Employees { get; }
        DbSet<Debit> Debits { get; }




        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
