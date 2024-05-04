using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyIdentityApi.Domain.Aggregates.UserAggregate;
using MyIdentityApi.Infrastructure.UnitOfWork;

namespace MyIdentityApi.Api.Application.Commands.UserCommands;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateUserCommand, IdentityResult>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    public async Task<IdentityResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var user = new User(request.FirstName, request.LastName, request.UserName, request.Email, request.PhoneNumber,
                request.CountryCodePhoneNumber);
            var result = await _unitOfWork.Users.CreateAsync(user, request.Password);
            if (!result.Succeeded) 
            {
                await _unitOfWork.RollbackTransactionAsync();
                return result;
            }
        
            await _unitOfWork.Users.AddToRoleAsync(user, "Admin");
            await _unitOfWork.Users.AddClaimAsync(user, new Claim("role", "Admin"));
            await _unitOfWork.Users.AddClaimAsync(user, new Claim("permission", "user_edit"));

            await _unitOfWork.CommitTransactionAsync();
            return result;
        }
        catch (Exception e)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw new Exception( "An error occurred while creating a user.", e);
        }
    }
}