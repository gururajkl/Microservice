using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Ecommerce.UserService.Infrastructure.DbContext;

/// <summary>
/// Represents a database context that provides access to a PostgreSQL database connection for use with Dapper.
/// </summary>
/// <remarks>
/// This context initializes a new database connection using the connection string specified in the
/// application's configuration under the key 'PostgresConnection'.
/// </remarks>
public class DapperDbContext
{
    private readonly IDbConnection _dbConnection;

    public DapperDbContext(IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("PostgresConnection");

        // Create new Npgsql connection using the connection string from appsettings.
        _dbConnection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _dbConnection;
}
