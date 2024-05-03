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
}