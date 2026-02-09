using Ecommerce.Core.DTOs;

namespace Ecommerce.Core.ServiceContracts;

/// <summary>
/// Defines business operations related to user management.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Authenticates a user using the provided login credentials.
    /// </summary>
    /// <param name="requestDto">The login request containing user credentials.</param>
    /// <returns>
    /// An <see cref="AuthenticationResponseDto"/> representing the authentication result, or <c>null</c> if the operation fails.
    /// </returns>
    Task<AuthenticationResponseDto?> LoginUserAsync(LoginRequestDto requestDto);
    /// <summary>
    /// Registers a new user using the provided registration details.
    /// </summary>
    /// <param name="requestDto">The registration request containing user details.</param>
    /// <returns>
    /// An <see cref="AuthenticationResponseDto"/> representing the registration result, or <c>null</c> if the operation fails.
    /// </returns>
    Task<AuthenticationResponseDto?> RegisterUserAsync(RegisterRequestDto requestDto);
}
