using AutoMapper;
using Ecommerce.ProductService.Core.DTOs;
using Ecommerce.ProductService.Infrastructure.Entities;

namespace Ecommerce.ProductService.Core.Mappers;

/// <summary>
/// Defines mapping configuration between the <see cref="Product"/> and the <see cref="ProductResponseDto"/> entity
/// with AutoMapper.
/// </summary>
public class ProductToProductResponseMappingProfile : Profile
{
    public ProductToProductResponseMappingProfile()
    {
        CreateMap<Product, ProductResponseDto>()
            .ForMember(destination => destination.ProductName, option => option.MapFrom(source => source.ProductName))
            .ForMember(destination => destination.UnitPrice, option => option.MapFrom(source => source.UnitPrice))
            .ForMember(destination => destination.QuantityInStock, option => option.MapFrom(source => source.QuantityInStock))
            .ForMember(destination => destination.Category, option => option.MapFrom(source => source.Category))
            .ForMember(destination => destination.ProductId, option => option.MapFrom(source => source.ProductId));
    }
}
