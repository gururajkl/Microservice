using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Ecommerce.Infrastructure.DbContext;

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
