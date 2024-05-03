using Microsoft.AspNetCore.Identity;

namespace MyIdentityApi.Domain.Aggregates.UserAggregate;

public class User : IdentityUser
{
    public string FirstName { get; private set; } = null!;

    public string LastName { get; private set; } = null!;
    
    public string CountryCodePhoneNumber { get; private set; } = null!;
    
    public User(string firstName, string lastName, string email, string phoneNumber, string countryCodePhoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = $"{firstName} {lastName}";
        NormalizedUserName = UserName.ToUpper();
        Email = email;
        NormalizedEmail = email.ToUpper();
        PhoneNumber = phoneNumber;
        CountryCodePhoneNumber = countryCodePhoneNumber;
    }
}