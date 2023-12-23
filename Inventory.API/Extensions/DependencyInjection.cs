using Inventory.API.Infrastructure;
using Inventory.API.Services;
using Inventory.API.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Extensions;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<InventoryContext>("InventoryContextConnection", configureDbContextOptions: dbContextOptionsBuilder =>
        {
            dbContextOptionsBuilder.UseNpgsql();
        });

        builder.Services.AddScoped<IInventoryService, InventoryService>();
    }
}