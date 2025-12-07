using DotNet.Testcontainers.Builders;
using GTShop.Server.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace GTShopTests.Fixtures;
public class SQLFixture : IAsyncLifetime
{
    public readonly MsSqlContainer _container;
    public string ConnectionString = "";
    public SQLFixture()
    {
        _container = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .WithPassword("YourStrong@Passw0rd")
        .WithWaitStrategy(Wait.ForUnixContainer().UntilInternalTcpPortIsAvailable(1433))
        .Build();
    }

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
        ConnectionString = _container.GetConnectionString();
    }

    public async Task DisposeAsync()
    {
        await _container.DisposeAsync();
    }

    public GTContext CreateDbContext()
    {
        ConnectionString = _container.GetConnectionString();
        var options = new DbContextOptionsBuilder<GTContext>()
            .UseSqlServer(ConnectionString)
            .Options;

        return new GTContext(options);
    }

   
}
