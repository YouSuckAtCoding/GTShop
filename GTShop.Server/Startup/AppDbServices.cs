using GTShop.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace GTShop.Server.Startup;

public static class AppDbServices
{

    public static IServiceCollection AddDbApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
    {

        services.AddDbContext<GTContext>(x =>
             x.UseSqlServer(
                 builder.Configuration.GetConnectionString("DbConnection")
            )
        );

        return services;

    }
}
