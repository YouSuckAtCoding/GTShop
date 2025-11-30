namespace GTShop.Server.Contracts.User.Requests;

public class UserRegisterRequest
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = ""; 
    public DateTime BirthDate { get; set; }
    public string SSN { get; set; } = "";
    public int Country { get; set; }
    public string City { get; set; } = "";
    public string Phone { get; set; } = "";
}
