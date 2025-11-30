using GTShop.Server.Contracts.User.Requests;
using GTShop.Server.Models;

namespace GTShop.Server.Mapper;

public static class UserMapper
{
    public static User ToUserModel(this UserRegisterRequest request)
    {
        return new User
        {
            Email = request.Email,
            BirthDate = request.BirthDate,
            SSN = request.SSN,
            Country = request.Country,
            City = request.City,
            Phone = request.Phone,
            UserName = request.Name
        };
    }
}
