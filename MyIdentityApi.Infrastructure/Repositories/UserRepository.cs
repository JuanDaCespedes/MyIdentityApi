using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MyIdentityApi.Domain.Aggregates.UserAggregate;

namespace MyIdentityApi.Infrastructure.Repositories;

public class UserRepository(UserManager<User> userManager) : IUserRepository
{
    private readonly UserManager<User> _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

    public async Task<IdentityResult> CreateAsync(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult> AddToRoleAsync(User user, string role)
    {
        return await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<IdentityResult> AddClaimAsync(User user, Claim claim)
    {
        return await _userManager.AddClaimAsync(user, claim);
    }
}