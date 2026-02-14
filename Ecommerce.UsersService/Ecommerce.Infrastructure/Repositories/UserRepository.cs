using Dapper;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Infrastructure.DbContext;

namespace Ecommerce.Infrastructure.Repositories;

internal class UserRepository(DapperDbContext dbContext) : IUserRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();

        string InsertQuery = "INSERT INTO public.\"Users\"(\"UserId\", \"Email\", \"PersonName\", \"Gender\", \"Password\") " +
            "VALUES (@UserId, @Email, @PersonName, @Gender, @Password)";

        int rowsAffected = await dbContext.DbConnection.ExecuteAsync(InsertQuery, user);

        return rowsAffected > 0 ? user : null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
    {
        return new()
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "Dummy",
            Gender = GenderOptions.Male.ToString()
        };
    }
}
