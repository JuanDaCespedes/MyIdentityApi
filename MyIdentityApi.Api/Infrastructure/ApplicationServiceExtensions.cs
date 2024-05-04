using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyIdentityApi.Domain.Aggregates.UserAggregate;
using MyIdentityApi.Infrastructure;
using MyIdentityApi.Infrastructure.Repositories;
using MyIdentityApi.Infrastructure.UnitOfWork;

namespace MyIdentityApi.Api.Infrastructure;

public static class ApplicationServiceExtensions
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<Program>();
            cfg.Lifetime = ServiceLifetime.Scoped;
        });
    }
    
    public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MyIdentityApiDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<MyIdentityApiDbContext>()
            .AddDefaultTokenProviders();
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        // AddUnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IUserRepository, UserRepository>();
    }
}