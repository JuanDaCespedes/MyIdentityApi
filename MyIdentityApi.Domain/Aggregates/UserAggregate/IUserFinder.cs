namespace MyIdentityApi.Domain.Aggregates.UserAggregate;

public interface IUserFinder
{
    Task<User> FindByNameAsync(string userName);
}