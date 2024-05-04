using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MyIdentityApi.Domain.Aggregates.UserAggregate;

namespace MyIdentityApi.Infrastructure.Repositories;

public class UserRepository(UserManager<User> userManager, SignInManager<User> signInManager) : IUserRepository
{
    private readonly UserManager<User> _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    private readonly SignInManager<User> _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));

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
    
    public async Task<bool> CheckPasswordAsync(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }
    
    public async Task SignInAsync(User user, bool isPersistent)
    {
        await _signInManager.SignInAsync(user, isPersistent);
    }
}