using MediatR;
using Microsoft.AspNetCore.Identity;

namespace MyIdentityApi.Api.Application.Commands.UserCommands;

public class LoginUserCommand(string userName, string password) : IRequest<IdentityResult>
{
    public string UserName { get; private set; } = userName;
    public string Password { get; private set; } = password;
}