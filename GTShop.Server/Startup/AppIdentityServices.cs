using GTShop.Server.Data;
using GTShop.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace GTShop.Server.Startup;

public static class AppIdentityServices
{
    public static IServiceCollection AddAppIdentityServices(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;

            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.MaxFailedAccessAttempts = 5;
        })
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<GTContext>();    

        return services;
    }
}
