using Dapper;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Infrastructure.DbContext;

namespace Ecommerce.Infrastructure.Repositories;

/// <summary>
/// Provides methods for managing user data, including adding new users and retrieving users by email and password.
/// </summary>
/// <remarks>
/// This repository uses Dapper for efficient database access and is intended for internal use within the
/// application.
/// </remarks>
/// <param name="dbContext">The database context used to perform user-related data operations.</param>
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
