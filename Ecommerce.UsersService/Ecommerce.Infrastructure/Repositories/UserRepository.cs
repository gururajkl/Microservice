using Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoryContracts;

namespace Ecommerce.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        return user;
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
