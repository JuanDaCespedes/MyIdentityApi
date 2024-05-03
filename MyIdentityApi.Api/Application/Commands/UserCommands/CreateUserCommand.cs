using MediatR;

namespace MyIdentityApi.Api.Application.Commands.UserCommands;

public class CreateUserCommand(
    string firstName,
    string lastName,
    string email,
    string password,
    string countryCodePhoneNumber,
    string phoneNumber)
    : IRequest
{
    public string FirstName { get; private set; } = firstName;

    public string LastName { get; private set; } = lastName;

    public string Email { get; private set; } = email;

    public string Password { get; private set; } = password;

    public string CountryCodePhoneNumber { get; private set; } = countryCodePhoneNumber;

    public string PhoneNumber { get; private set; } = phoneNumber;
}