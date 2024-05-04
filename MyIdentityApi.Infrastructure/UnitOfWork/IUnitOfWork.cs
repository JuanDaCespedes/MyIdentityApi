using MyIdentityApi.Domain.Aggregates.UserAggregate;

namespace MyIdentityApi.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    Task<bool> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}