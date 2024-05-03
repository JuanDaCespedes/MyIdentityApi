using MediatR;

namespace MyIdentityApi.Api.Application.Commands.UserCommands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine(request.FirstName);
        Console.WriteLine(request.LastName);
        Console.WriteLine(request.Email);
        Console.WriteLine(request.Password);
        Console.WriteLine(request.CountryCodePhoneNumber);
        Console.WriteLine(request.PhoneNumber);
    }
}