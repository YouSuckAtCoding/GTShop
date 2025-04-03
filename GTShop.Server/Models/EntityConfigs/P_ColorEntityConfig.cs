using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTShop.Server.Models.EntityConfigs;

public class P_ColorEntityConfig : IEntityTypeConfiguration<P_Color>
{
    public void Configure(EntityTypeBuilder<P_Color> builder)
    {       
        builder.HasKey(x => x.Id);
    }
}