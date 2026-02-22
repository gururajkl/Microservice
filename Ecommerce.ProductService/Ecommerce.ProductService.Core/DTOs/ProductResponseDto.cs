namespace Ecommerce.ProductService.Core.DTOs;

public record ProductResponseDto(Guid ProductId, string? ProductName, CategoryOptionDto CategoryOption, double? UnitPrice, int? Quantity)
{
    // We need parameter less ctor for the fluent API.
    public ProductResponseDto() : this(default, default, default, default, default) { }
}
