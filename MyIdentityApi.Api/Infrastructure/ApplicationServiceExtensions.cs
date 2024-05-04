using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyIdentityApi.Domain.Aggregates.UserAggregate;
using MyIdentityApi.Infrastructure;
using MyIdentityApi.Infrastructure.Finder;
using MyIdentityApi.Infrastructure.Repositories;
using MyIdentityApi.Infrastructure.UnitOfWork;
using Npgsql;

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
        
        services.AddIdentity<Domain.Aggregates.UserAggregate.User, IdentityRole>()
            .AddEntityFrameworkStores<MyIdentityApiDbContext>()
            .AddDefaultTokenProviders();
    }
    
    public static void AddConfigurationDapper(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection>(x =>
            new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")));
    }
    public static void AddRepositories(this IServiceCollection services)
    {
        // AddUnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IUserRepository, UserRepository>();
    }
    
    public static void AddFinder(this IServiceCollection services)
    {
        services.AddScoped<IUserFinder, UserFinder>();
    }
}