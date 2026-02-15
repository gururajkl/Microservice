using Ecommerce.UserService.Core.Entities;

namespace Ecommerce.UserService.Core.RepositoryContracts;

/// <summary>
/// Defines data access operations related to application users.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Adds a new user to the data store.
    /// </summary>
    /// <param name="user">The application user entity to be added.</param>
    /// <returns>
    /// The created <see cref="ApplicationUser"/> if the operation succeeds otherwise, <c>null</c>.
    /// </returns>
    Task<ApplicationUser?> AddUserAsync(ApplicationUser user);
    /// <summary>
    /// Retrieves a user by matching email and password credentials.
    /// </summary>
    /// <param name="email">The email address associated with the user.</param>
    /// <param name="password">The password used for authentication.</param>
    /// <returns>
    /// The matching <see cref="ApplicationUser"/> if credentials are valid otherwise, <c>null</c>.
    /// </returns>
    Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password);
}
