using GTShop.Server.Contracts.User;
using GTShop.Server.Contracts.User.Requests;
using GTShop.Server.Endpoints;
using GTShop.Server.Mapper;
using GTShop.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GTShop.Server.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly IEmailSender<User> _sender;

    public UserController(SignInManager<User> signInManager, IEmailSender<User> sender)
    {
        _signInManager = signInManager;
        _sender = sender;
    }

    [HttpPost(Endpoints.UserEndpoints.Identity.Register)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        var validationResults = UserValidator.Validate(request);
        if (!validationResults.IsValid)
            return BadRequest(validationResults.Errors);

        var mappedUser = request.ToUserModel();
        var result = await _signInManager.UserManager.CreateAsync(mappedUser, request.Password);

        if (result.Succeeded)
        {
            var emailToken = await _signInManager.UserManager.GenerateEmailConfirmationTokenAsync(mappedUser);

            var confirmationLink = $"{Request.Scheme}://{Request.Host}{UserEndpoints.Identity.ConfirmEmail}" +
                $"?userId={Uri.EscapeDataString(mappedUser.Id)}&token={Uri.EscapeDataString(emailToken)}";

            _ = _sender.SendConfirmationLinkAsync(mappedUser,
                                                  email: "",
                                                  confirmationLink: confirmationLink);

            return StatusCode(201, confirmationLink);
        }

        if(result.Errors.Any())
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            return BadRequest(errors);
        }

        return StatusCode(500);
    }

    [HttpGet(UserEndpoints.Identity.ConfirmEmail)]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        var user = await _signInManager.UserManager.FindByIdAsync(userId);
        if (user is null)
            return BadRequest("Invalid user ID.");

        var result = await _signInManager.UserManager.ConfirmEmailAsync(user, token);

        if (result.Succeeded)
            return Ok("Email confirmed successfully.");
        
        else
            return BadRequest("Email confirmation failed.");
        
    }
}




