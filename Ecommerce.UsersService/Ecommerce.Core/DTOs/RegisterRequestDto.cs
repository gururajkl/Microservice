namespace Ecommerce.Core.DTOs;

/// <summary>
/// Represents a data required to register new account.
/// </summary>
/// <param name="Email">Email of the user.</param>
/// <param name="Password">Password to create account.</param>
/// <param name="PersonName">Name of the person.</param>
/// <param name="Gender">Gender of the person.</param>
public record RegisterRequestDto(string? Email, string? Password, string? PersonName, GenderOptions Gender);
