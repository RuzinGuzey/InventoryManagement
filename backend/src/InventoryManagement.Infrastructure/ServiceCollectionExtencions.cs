using InventoryManagement.Application.Common.Interface;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InventoryManagement.Infrastructure
{
    public static class ServiceCollectionExtencions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            });



            return services;
        }

    }
}
