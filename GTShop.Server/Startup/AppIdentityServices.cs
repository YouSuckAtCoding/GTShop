using GTShop.Server.Data;
using GTShop.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace GTShop.Server.Startup;

public static class AppIdentityServices
{
    public static IServiceCollection AddAppIdentityServices(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<GTContext>()
            .AddApiEndpoints();

        return services;
    }
}
