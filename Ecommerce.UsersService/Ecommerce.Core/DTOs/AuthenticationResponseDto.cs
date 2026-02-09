namespace Ecommerce.Core.DTOs;

/// <summary>
/// Represents the response returned after an authentication attempt.
/// </summary>
/// <param name="UserId">The unique identifier of the authenticated user.</param>
/// <param name="Email">The email address associated with the user, if available.</param>
/// <param name="PersonName">The full name of the authenticated user, if available.</param>
/// <param name="Gender">The gender of the authenticated user, if available.</param>
/// <param name="Token">The authentication token issued upon successful login otherwise, <c>null</c>.</param>
/// <param name="IsSuccess">Indicates whether the authentication operation was successful.</param>
public record AuthenticationResponseDto(Guid UserId, string? Email, string? PersonName, string? Gender, string? Token, bool IsSuccess)
{
    // Need this ctor to fulfill the automapper.
    public AuthenticationResponseDto() : this(default, default, default, default, default, default)
    { }
}
