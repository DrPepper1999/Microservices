using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.API.Infrastructure.EntityConfigurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Model.Product>
{
    public void Configure(EntityTypeBuilder<Model.Product> builder)
    {
        builder.ToTable("Product");
    }
}