using GTShop.Server.Data;
using GTShop.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace GTShop.Server.Startup;

public static class AppServicesRegistration
{
    public static IServiceCollection AddDIServices(this IServiceCollection services)
    {
        services.AddSingleton<IEmailSender<User>,EmailSender>();


        return services;
    }
}
