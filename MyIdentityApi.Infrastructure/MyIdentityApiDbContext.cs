using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyIdentityApi.Domain.Aggregates.UserAggregate;

namespace MyIdentityApi.Infrastructure;

public class MyIdentityApiDbContext(DbContextOptions<MyIdentityApiDbContext> options) : IdentityDbContext<User>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString()},
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Manager", NormalizedName = "MANAGER", ConcurrencyStamp = Guid.NewGuid().ToString()},
            new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString()}
        );
    }
}