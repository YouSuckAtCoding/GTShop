using GTShop.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace GTShop.Server.Services;

public interface IEmailService<TUser> : IEmailSender<User>
{
    string GetConfirmationLink(TUser user, string token, HttpRequest request);
}

