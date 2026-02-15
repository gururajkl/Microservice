using Ecommerce.Core.DTOs;
using Ecommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

/// <summary>
/// Controller responsible which maintains user account.
/// </summary>
/// <param name="userService"><see cref="IUserService"/> provides implementation to perform user account action.</param>
[ApiController]
[Route("api/[controller]")]
public class AuthController(IUserService userService) : ControllerBase
{
    // Endpoint for user registration.
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto requestDto)
    {
        if (requestDto is null)
        {
            return BadRequest("Invalid user registration data");
        }

        AuthenticationResponseDto? responseDto = await userService.RegisterUserAsync(requestDto);

        if (responseDto is null || !responseDto.IsSuccess)
        {
            return BadRequest(responseDto);
        }

        return Ok(responseDto);
    }

    // Endpoint for user login.
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto requestDto)
    {
        if (requestDto is null)
        {
            return BadRequest("Invalid user login data");
        }

        AuthenticationResponseDto? responseDto = await userService.LoginUserAsync(requestDto);

        if (responseDto is null || !responseDto.IsSuccess)
        {
            return Unauthorized(responseDto);
        }

        return Ok(responseDto);
    }
}
