using Microsoft.AspNetCore.Identity;

namespace MyIdentityApi.Domain.Aggregates.UserAggregate;

public class User : IdentityUser
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }
    
    public string CountryCodePhoneNumber { get; private set; }
    
    public User(string firstName, string lastName, string userName, string email, string phoneNumber, string countryCodePhoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        NormalizedUserName = UserName.ToUpper();
        Email = email;
        NormalizedEmail = email.ToUpper();
        PhoneNumber = phoneNumber;
        CountryCodePhoneNumber = countryCodePhoneNumber;
    }
}