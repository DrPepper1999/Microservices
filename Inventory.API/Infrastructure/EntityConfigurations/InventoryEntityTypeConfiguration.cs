using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.API.Infrastructure.EntityConfigurations;

public class InventoryEntityTypeConfiguration : IEntityTypeConfiguration<Model.Inventory>
{
    public void Configure(EntityTypeBuilder<Model.Inventory> builder)
    {
        builder.ToTable("Inventory");

        builder.HasKey(i => i.Id);
        
        builder.HasIndex(i => i.ProductId);
    }   
}