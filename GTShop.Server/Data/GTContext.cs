using GTShop.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GTShop.Server.Data;

public class GTContext : IdentityDbContext<User>
{
    public GTContext() : base()
    {
    }

    public GTContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GTContext).Assembly);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<P_Color> MyProperty { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Cart_Item> Cart_Items { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Order_Item> Order_Items { get; set; }
    public DbSet<P_Color> P_Colors { get; set; }
}

