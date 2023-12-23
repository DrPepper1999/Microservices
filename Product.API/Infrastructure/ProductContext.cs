using Microsoft.EntityFrameworkCore;
using Product.API.Infrastructure.EntityConfigurations;

namespace Product.API.Infrastructure;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options, IConfiguration configuration) : base(options)
    {
    }
    
    public DbSet<Model.Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());

        modelBuilder.Entity<Model.Product>().HasData(
            new List<Model.Product>()
            {
                new()
                {
                    Id = Guid.Parse("3AA8CC33-47DA-4B19-BF36-6A6429244E7E"),
                    Name = "Картошка",
                    Description = "Сырая",
                    Weight = 1
                },
                new()
                {
                    Id = Guid.Parse("EF798709-FC38-41FD-A262-61117B1AB91F"),
                    Name = "Марковка",
                    Description = "Сырая",
                    Weight = 1
                },
                new()
                {
                    Id = Guid.Parse("23CB36D8-EA5F-42F8-BADD-FFA6CE6D62C2"),
                    Name = "Вода",
                    Description = "не газированая",
                    Weight = 2
                },
                new()
                {
                    Id = Guid.Parse("733D1CE3-CB68-441C-8640-31BFCA4A6C50"),
                    Name = "Хлеб белый",
                    Description = "Вкусный",
                    Weight = 0.2m
                },
                new()
                {
                    Id = Guid.Parse("C339A5E3-BCC9-4CAD-B128-96016FCCF794"),
                    Name = "Хлеб чёрный",
                    Description = "Чёрствый",
                    Weight = 0.1m
                },
                new()
                {
                    Id = Guid.Parse("13941B7C-1CEB-4D02-96B1-BA2571C6671A"),
                    Name = "Пельмени",
                    Description = "С мясом",
                    Weight = 0.750m
                },
            });
    }
}