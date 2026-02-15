namespace Ecommerce.UserService.Core.DTOs;

/// <summary>
/// Represents a request containing user credentials for authentication.
/// </summary>
/// <param name="Email">The email address of the user attempting to log in. This parameter cannot be null or empty.</param>
/// <param name="Password">The password associated with the user's account. This parameter cannot be null or empty.</param>
public record LoginRequestDto(string? Email, string? Password);
