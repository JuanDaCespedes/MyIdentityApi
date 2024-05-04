using System.Data;
using Dapper;

namespace MyIdentityApi.Infrastructure.Finder;

public abstract class FinderBase(IDbConnection connection)
{
    protected readonly IDbConnection Connection = connection ?? throw new ArgumentNullException(nameof(connection));
    
    protected async Task<T> ExecuteFirstOrDefaultAsync<T>(string query, object? parameters = null)
    {
        return await Connection.QueryFirstOrDefaultAsync<T>(query, parameters);
    }
    
    protected async Task<T> ExecuteQuerySingleOrDefaultAsync<T>(string query, object? parameters = null)
    {
        return await Connection.QuerySingleOrDefaultAsync<T>(query, parameters);
    }
}