using GTShop.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace GTShop.Server.Extensions;

public static class MigrationsExtensions
{
    public static void UpdateMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using GTContext context = scope.ServiceProvider.GetRequiredService<GTContext>();

        context.Database.Migrate();
    }
}
