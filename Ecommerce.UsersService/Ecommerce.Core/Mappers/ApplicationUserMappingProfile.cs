using AutoMapper;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;

namespace Ecommerce.Core.Mappers;

/// <summary>
/// Defines an AutoMapper profile for mapping properties from the <see cref="ApplicationUser"/> entity to the
/// <see cref="AuthenticationResponseDto"/> data transfer object.
/// </summary>
public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponseDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.IsSuccess, opt => opt.Ignore())
            .ForMember(dest => dest.Token, opt => opt.Ignore());
    }
}
