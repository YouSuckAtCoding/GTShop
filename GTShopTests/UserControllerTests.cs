using GTShop.Server.Contracts.User.Requests;
using GTShop.Server.Endpoints;
using GTShop.Server.Models;
using GTShopTests.ApiHandler;
using GTShopTests.Fixtures;
using GTShopTests.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http.Json;

namespace GTShopTests;
public class UserControllerTests : IClassFixture<SQLFixture>
{
    private readonly SQLFixture _fixture;

    public UserControllerTests(SQLFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Should_Create_User_And_Send_Confirmation_EmailAsync()
    {
        var user = new UserRegisterRequest
        {
            Name = "testuser",
            Email = "testuser@test.com",
            BirthDate = new DateTime(1990, 1, 1),
            SSN = "123-45-6789",
            Country = 1,
            City = "TestCity",
            Phone = "123-456-7890",
            Password = "@Test1234"
        };

        var api = CreateApiWithMockedServiceImplementation<EmailService>().CreateClient();

        var response = await api.PostAsJsonAsync(UserEndpoints.Identity.Register, user);

        var link = await response.Content.ReadAsStringAsync();

        var finalResposne = await api.GetAsync(link);
        finalResposne.EnsureSuccessStatusCode();

    }

    private ApiFactory CreateApiWithMockedServiceImplementation<T>()
        where T : class, IEmailSender<User>
    {
        var connectionString = _fixture.ConnectionString;
        var api = new ApiFactory(services =>
        {

            services.RemoveAll(typeof(IEmailSender<User>));
            services.TryAddScoped<IEmailSender<User>, T>();


        }, connectionString);
        return api;


    }
}
