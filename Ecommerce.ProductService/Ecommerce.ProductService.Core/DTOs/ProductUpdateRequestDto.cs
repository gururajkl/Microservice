namespace Ecommerce.ProductService.Core.DTOs;

public record ProductUpdateRequestDto(Guid ProductId, string? ProductName, CategoryOptionDto CategoryOption, double? UnitPrice, int? Quantity)
{
    // We need parameter less ctor for the fluent API.
    public ProductUpdateRequestDto() : this(default, default, default, default, default) { }
}
