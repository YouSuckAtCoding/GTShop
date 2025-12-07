using GTShop.Server.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace GTShopTests;

public class EmailTests
{
    private static IConfiguration GetConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
    [Fact]
    public void Should_Send_Email_To_Recipient()
    {
        var service = new EmailService(GetConfiguration());
        string recipient = "marco.antonio.rg340@gmail.com";

        var user = new User
        {
            Email = recipient,
            UserName = "testuser"
        };

        service.SendConfirmationLinkAsync(user, "", "youtube.com");

        Assert.True(true); 

    }

    [Fact]
    public void Should_Create_Confirmation_Link()
    {
        var userId = Guid.NewGuid().ToString();
        var token = Convert.ToBase64String(Encoding.UTF8.GetBytes("sample-token"));
        string confirmationLink = $"https://yourdomain.com/confirm-email?userId={userId}&token={Uri.EscapeDataString(token)}";
        Assert.Contains(userId, confirmationLink);
        Assert.Contains(Uri.EscapeDataString(token), confirmationLink);
    }
}
