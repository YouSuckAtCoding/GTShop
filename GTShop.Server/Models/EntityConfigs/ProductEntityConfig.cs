using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTShop.Server.Models.EntityConfigs;

public class ProductEntityConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Msrp).IsRequired().HasColumnType("decimal(19,2)");
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Image_1).IsRequired();
        builder.HasMany(X => X.Colors);
    }
}
