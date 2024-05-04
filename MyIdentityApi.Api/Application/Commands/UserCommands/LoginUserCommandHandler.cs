using MediatR;
using Microsoft.AspNetCore.Identity;
using MyIdentityApi.Domain.Aggregates.UserAggregate;
using MyIdentityApi.Infrastructure.UnitOfWork;

namespace MyIdentityApi.Api.Application.Commands.UserCommands;

public class LoginUserCommandHandler(IUnitOfWork unitOfWork, IUserFinder userFinder) : IRequestHandler<LoginUserCommand, IdentityResult>
{
    private readonly IUserFinder _userFinder = userFinder ?? throw new ArgumentNullException(nameof(userFinder));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task<IdentityResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userFinder.FindByNameAsync(request.UserName);

        if (user == null) return IdentityResult.Failed(new IdentityError { Description = "Invalid login attempt" });
        var result = await _unitOfWork.Users.CheckPasswordAsync(user, request.Password);
        if (!result)
            return IdentityResult.Failed(new IdentityError { Description = "Invalid login attempt" });
        await _unitOfWork.Users.SignInAsync(user, isPersistent: result);
        return IdentityResult.Success;
    }
}