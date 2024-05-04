using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace MyIdentityApi.Domain.Aggregates.UserAggregate;

public interface IUserRepository
{
    Task<IdentityResult> CreateAsync(User user, string password);
    Task<IdentityResult> AddToRoleAsync(User user, string role);
    Task<IdentityResult> AddClaimAsync(User user, Claim claim);
    Task<bool> CheckPasswordAsync(User user, string password);
    Task SignInAsync(User user, bool isPersistent);
}