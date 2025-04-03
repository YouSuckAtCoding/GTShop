using Microsoft.EntityFrameworkCore;

namespace GTShop.Server.Models.EntityConfigs;

public class CartItemEntityConfig : IEntityTypeConfiguration<Cart_Item>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cart_Item> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
