using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MyIdentityApi.Api.Application.Commands.UserCommands;

public class CreateUserCommand(
    string firstName,
    string lastName,
    string userName,
    string email,
    string password,
    string countryCodePhoneNumber,
    string phoneNumber)
    : IRequest<IdentityResult>
{
    public string FirstName { get; private set; } = firstName;

    public string LastName { get; private set; } = lastName;
    
    public string UserName { get; private set; } = userName;

    public string Email { get; private set; } = email;

    public string Password { get; private set; } = password;

    public string CountryCodePhoneNumber { get; private set; } = countryCodePhoneNumber;

    public string PhoneNumber { get; private set; } = phoneNumber;
}