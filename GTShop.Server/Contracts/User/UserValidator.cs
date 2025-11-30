using GTShop.Server.Contracts.User.Requests;

namespace GTShop.Server.Contracts.User;

public static class UserValidator
{
    private const int MinAge = 18;
    private const int MaxAge = 120;

    public static (bool IsValid, List<string> Errors) Validate(UserRegisterRequest dto)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(dto.Name))
            errors.Add("Email is required");


        if (string.IsNullOrWhiteSpace(dto.Email))      
            errors.Add("Email is required");
        else if (!IsValidEmail(dto.Email))        
            errors.Add("Email format is invalid");
        

        if (string.IsNullOrWhiteSpace(dto.Password))
            errors.Add("Password is required");
        else if (dto.Password.Length < 8)
            errors.Add("Password must be at least 8 characters long");
        else if (!HasUpperCase(dto.Password))        
            errors.Add("Password must contain at least one uppercase letter");
        else if (!HasLowerCase(dto.Password))
            errors.Add("Password must contain at least one lowercase letter");
        else if (!HasDigit(dto.Password))
            errors.Add("Password must contain at least one digit");
        else if (!HasSpecialChar(dto.Password))
            errors.Add("Password must contain at least one special character");
        

        if (dto.BirthDate == default)
            errors.Add("Birth date is required");
        else if (dto.BirthDate > DateTime.Now)
            errors.Add("Birth date cannot be in the future");
        else if (!IsValidAge(dto.BirthDate, minAge: MinAge))
            errors.Add($"You must be at least {MinAge} years old");
        else if (!IsValidAge(dto.BirthDate, maxAge: MaxAge))
            errors.Add("Invalid birth date");
        

        if (string.IsNullOrWhiteSpace(dto.SSN))
            errors.Add("SSN is required");
        else if (!IsValidSSN(dto.SSN))
            errors.Add("SSN format is invalid (expected format: XXX-XX-XXXX)");
        

        if (dto.Country <= 0)
            errors.Add("Country is required");
        if (string.IsNullOrWhiteSpace(dto.City))
            errors.Add("City is required");
        else if (dto.City.Length < 2)
            errors.Add("City must be at least 2 characters long");
        else if (dto.City.Length > 100)
            errors.Add("City must not exceed 100 characters");
                

        if (string.IsNullOrWhiteSpace(dto.Phone))
            errors.Add("Phone number is required");
        else if (!IsValidPhone(dto.Phone))        
            errors.Add("Phone number format is invalid");
        
        return (errors.Count == 0, errors);
    }

    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private static bool HasUpperCase(string str) => str.Any(char.IsUpper);

    private static bool HasLowerCase(string str) => str.Any(char.IsLower);

    private static bool HasDigit(string str) => str.Any(char.IsDigit);

    private static bool HasSpecialChar(string str) =>
        str.Any(c => !char.IsLetterOrDigit(c));

    private static bool IsValidAge(DateTime birthDate, 
                                    int? minAge = null,
                                    int? maxAge = null)
    {
        var age = DateTime.Now.Year - birthDate.Year;
        if (birthDate.Date > DateTime.Now.AddYears(-age))
            age--;

        if (minAge.HasValue && age < minAge.Value)
            return false;

        if (maxAge.HasValue && age > maxAge.Value)
            return false;

        return true;
    }

    private static bool IsValidSSN(string ssn)
    {
        if (string.IsNullOrWhiteSpace(ssn))
            return false;

        var cleanSSN = ssn.Replace("-", "").Replace(" ", "").Replace(".", "");

        return cleanSSN.All(char.IsNumber);
    }

    private static bool IsValidPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        var cleanPhone = phone.Replace("-", "")
                             .Replace("(", "")
                             .Replace(")", "")
                             .Replace(" ", "")
                             .Replace("+", "");

        return cleanPhone.Length >= 10 &&
               cleanPhone.Length <= 15 &&
               cleanPhone.All(char.IsDigit);
    }
}

