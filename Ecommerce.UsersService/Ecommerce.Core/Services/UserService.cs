using AutoMapper;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Core.ServiceContracts;

namespace Ecommerce.Core.Services;

internal class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<AuthenticationResponseDto?> LoginUserAsync(LoginRequestDto requestDto)
    {
        ApplicationUser? user = await userRepository.GetUserByEmailAndPasswordAsync(requestDto.Email, requestDto.Password);

        if (user is null)
        {
            return null;
        }

        return mapper.Map<AuthenticationResponseDto>(user) with
        {
            IsSuccess = true,
            Token = "token"
        };
    }

    public async Task<AuthenticationResponseDto?> RegisterUserAsync(RegisterRequestDto requestDto)
    {
        ApplicationUser user = new()
        {
            Email = requestDto.Email,
            Password = requestDto.Password,
            Gender = requestDto.Gender.ToString(),
            PersonName = requestDto.PersonName,
        };

        ApplicationUser? createdUser = await userRepository.AddUserAsync(user);

        if (createdUser is null)
        {
            return null;
        }

        return mapper.Map<AuthenticationResponseDto>(createdUser) with
        {
            IsSuccess = true,
            Token = "token"
        };
    }
}
