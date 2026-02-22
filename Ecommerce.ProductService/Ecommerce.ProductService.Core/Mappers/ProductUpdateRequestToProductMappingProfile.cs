using AutoMapper;
using Ecommerce.ProductService.Core.DTOs;
using Ecommerce.ProductService.Infrastructure.Entities;

namespace Ecommerce.ProductService.Core.Mappers;

/// <summary>
/// Defines mapping configuration between the <see cref="ProductUpdateRequestDto"/> and the <see cref="Product"/> entity
/// with AutoMapper.
/// </summary>
public class ProductUpdateRequestToProductMappingProfile : Profile
{
    public ProductUpdateRequestToProductMappingProfile()
    {
        CreateMap<ProductUpdateRequestDto, Product>()
            .ForMember(destination => destination.ProductName, option => option.MapFrom(source => source.ProductName))
            .ForMember(destination => destination.UnitPrice, option => option.MapFrom(source => source.UnitPrice))
            .ForMember(destination => destination.QuantityInStock, option => option.MapFrom(source => source.QuantityInStock))
            .ForMember(destination => destination.Category, option => option.MapFrom(source => source.Category))
            .ForMember(destination => destination.ProductId, option => option.MapFrom(source => source.ProductId));
    }
}
