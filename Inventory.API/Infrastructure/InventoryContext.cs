using Inventory.API.Infrastructure.EntityConfigurations;
using Inventory.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Infrastructure;

public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options, IConfiguration configuration) : base(options)
    {
    }
    
    public DbSet<Model.Inventory> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InventoryEntityTypeConfiguration());
        
        modelBuilder.Entity<Model.Inventory>().HasData(
            new List<Model.Inventory>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("3AA8CC33-47DA-4B19-BF36-6A6429244E7E"),
                    Name = "Картошка",
                    Count = 200,
                    Price = 40
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("EF798709-FC38-41FD-A262-61117B1AB91F"),
                    Name = "Марковка",
                    Count = 300,
                    Price = 35
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("23CB36D8-EA5F-42F8-BADD-FFA6CE6D62C2"),
                    Name = "Вода",
                    Count = 500,
                    Price = 80
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("733D1CE3-CB68-441C-8640-31BFCA4A6C50"),
                    Name = "Хлеб белый",
                    Count = 600,
                    Price = 50
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("C339A5E3-BCC9-4CAD-B128-96016FCCF794"),
                    Name = "Хлеб чёрный",
                    Count = 300,
                    Price = 50
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.Parse("13941B7C-1CEB-4D02-96B1-BA2571C6671A"),
                    Name = "Пельмени",
                    Price = 200,
                    Count = 250
                },
            });
    }
}