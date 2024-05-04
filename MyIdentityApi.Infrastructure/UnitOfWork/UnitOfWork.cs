using Microsoft.Extensions.DependencyInjection;
using MyIdentityApi.Domain.Aggregates.UserAggregate;

namespace MyIdentityApi.Infrastructure.UnitOfWork;

public class UnitOfWork(MyIdentityApiDbContext context, IServiceProvider serviceProvider)
    : IUnitOfWork, IDisposable
{
    private readonly MyIdentityApiDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IServiceProvider _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

    private IUserRepository _userRepository;

    public IUserRepository Users => _userRepository ??= _serviceProvider.GetRequiredService<IUserRepository>();

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task BeginTransactionAsync()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _context.Database.CommitTransactionAsync();
        }
        catch
        {
            await _context.Database.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}