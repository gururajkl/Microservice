using Dapper;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Infrastructure.DbContext;

namespace Ecommerce.Infrastructure.Repositories;

internal class UserRepository(DapperDbContext dbContext) : IUserRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        string insertQuery = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") " +
            "VALUES (@UserId, @Email, @PersonName, @Gender, @Password)";

        int rowsAffected = await dbContext.DbConnection.ExecuteAsync(insertQuery, user);

        return rowsAffected > 0 ? user : null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
    {
        string selectQuery = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
        var parameters = new { Email = email, Password = password };

        ApplicationUser? user = await dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(selectQuery, parameters);

        return user;
    }
}
