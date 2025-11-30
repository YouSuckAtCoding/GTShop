using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GTShop.Server.Models;

public class User : IdentityUser
{
    [Required]
    [PersonalData]
    public DateTime BirthDate { get; set; }

    [Required]
    [PersonalData]
    public string SSN { get; set; } = "";

    [Required]
    [PersonalData]
    public int Country { get; set; }

    [Required]
    [PersonalData]
    public string City { get; set; } = "";

    [Required]
    [PersonalData]
    public string Phone { get; set; } = "";
}
