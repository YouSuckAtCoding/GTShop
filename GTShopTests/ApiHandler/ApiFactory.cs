using GTShop.Server;
using GTShop.Server.Data;
using GTShop.Server.Models;
using GTShop.Server.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GTShopTests.ApiHandler;
public class ApiFactory : WebApplicationFactory<IAssemblyMarker>
{
    private readonly Action<IServiceCollection> _config;
    private string ConnectionString;

    public ApiFactory(Action<IServiceCollection> config, string _ConnectionString)
    {
        _config = config;
        ConnectionString = _ConnectionString;
    }

    public Action<IServiceCollection> Configure { get; }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");

        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IdentityDbContext));
            services.RemoveAll(typeof(IEmailService<User>));
            services.RemoveAll<DbContextOptions<GTContext>>();
            services.RemoveAll<DbContextOptions<IdentityDbContext>>();
            

            services.AddScoped<IEmailSender>(s => null!);

            services.AddDbContext<GTContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });

            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GTContext>();

            dbContext.Database.Migrate();

            _config(services);

        });
    }
}
