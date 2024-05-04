using System.Data;
using MyIdentityApi.Domain.Aggregates.UserAggregate;

namespace MyIdentityApi.Infrastructure.Finder;

public class UserFinder(IDbConnection connection) : FinderBase(connection), IUserFinder
{
    
    public Task<User> FindByNameAsync(string userName)
    {
        const string query = """SELECT * FROM "AspNetUsers" WHERE "UserName" = @UserName""";
        return ExecuteFirstOrDefaultAsync<User>(query, new { UserName = userName });
    }
}