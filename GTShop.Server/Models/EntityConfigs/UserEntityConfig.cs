using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTShop.Server.Models.EntityConfigs;

public class UserEntityConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.UserName).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.BirthDate).IsRequired();
        builder.Property(x => x.SSN).IsRequired();
        builder.HasIndex(x => x.SSN).IsUnique();
        builder.Property(x => x.Country).IsRequired();
        builder.Property(x => x.City).IsRequired();
        builder.Property(x => x.Phone).IsRequired();

    }
}
