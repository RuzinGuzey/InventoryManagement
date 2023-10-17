using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Inventory> Inventories => Set<Inventory>();

        public DbSet<InventoryGroup> InventoryGroups => Set<InventoryGroup>();

        public DbSet<VehicleInventory> VehicleInventories => Set<VehicleInventory>();
        public DbSet<Communication> Communications => Set<Communication>();
        public DbSet<Debit> Debits => Set<Debit>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Insurance> Insurances => Set<Insurance>();
        public DbSet<Maintenance> Maintenances => Set<Maintenance>();
        public DbSet<Operator> Operators => Set<Operator>();
        public DbSet<VehicleInspection> VehicleInspections => Set<VehicleInspection>();
    }
}
