using Microsoft.AspNetCore.Identity;

namespace GTShop.Server.Models;

public class User : IdentityUser
{
    [PersonalData]
    public DateTime BirthDate { get; set; }
    [PersonalData]
    public string SSN { get; set; } = "";
    [PersonalData]
    public int Country { get; set; }
    [PersonalData]
    public string City { get; set; } = "";
    [PersonalData]
    public string Phone { get; set; } = "";
}
