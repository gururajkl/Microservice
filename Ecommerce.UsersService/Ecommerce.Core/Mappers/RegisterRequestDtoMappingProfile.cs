using AutoMapper;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;

namespace Ecommerce.Core.Mappers;

/// <summary>
/// Defines an AutoMapper profile for mapping properties from the <see cref="RegisterRequestDto"/> entity to the
/// <see cref="ApplicationUser"/> data transfer object.
/// </summary>
public class RegisterRequestDtoMappingProfile : Profile
{
    public RegisterRequestDtoMappingProfile()
    {
        CreateMap<RegisterRequestDto, ApplicationUser>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));
    }
}
