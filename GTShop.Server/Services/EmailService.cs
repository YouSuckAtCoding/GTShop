using Azure.Core;
using GTShop.Server.Endpoints;
using GTShop.Server.Models;
using GTShop.Server.Services;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;

public class EmailService : IEmailService<User>
{
    private const string SenderEmailAddress = "marcoantoniodoom@gmail.com";
    private IConfiguration _config;
    public EmailService(IConfiguration config)
    {
        _config = config;
    }
    public Task SendConfirmationLinkAsync(User user, string email = "", string confirmationLink = "")
    {

        SendEmail(user.Email!, "Register Confirmation on GTShop", $"Congrats on registering. Click here to confirm {confirmationLink}" +
                                                                                            ". Our 'team' needs to make a decent email body.");
        Console.WriteLine($"Confirmation link for {email}: {confirmationLink}");
        return Task.CompletedTask;
    }
    public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
    {
        // TODO: Implement email sending
        Console.WriteLine($"Password reset link for {email}: {resetLink}");
        return Task.CompletedTask;
    }
    public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
    {
        // TODO: Implement email sending
        Console.WriteLine($"Password reset code for {email}: {resetCode}");
        return Task.CompletedTask;
    }
    public string GetConfirmationLink(User mappedUser, string emailToken, HttpRequest controllerRequest)
    {
        return $"{controllerRequest.Scheme}://{controllerRequest.Host}{UserEndpoints.Identity.ConfirmEmail}" +
            $"?userId={Uri.EscapeDataString(mappedUser.Id)}&token={Uri.EscapeDataString(emailToken)}";
    }
    private void SendEmailHandler(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled)
            Console.WriteLine("Email send was cancelled.");
        
        else if (e.Error != null)
            Console.WriteLine($"Error sending email: {e.Error.Message}");
        
        else
            Console.WriteLine("Email sent successfully!");

        var userToken = e.UserState;
        Console.WriteLine($"User token: {userToken}");
    }
    private void SendEmail(string Recipient, string Subject, string body, CancellationToken token = default)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(SenderEmailAddress);
            mail.To.Add(Recipient);
            mail.Subject = Subject;
            mail.Body = body;
            mail.IsBodyHtml = false;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587; // TLS port (or use 465 for SSL)
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(SenderEmailAddress, _config.GetValue<string>("EmailKey"));
            smtpClient.SendCompleted += SendEmailHandler;

            smtpClient.SendAsync(mail, token);
            Console.WriteLine("Email sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}