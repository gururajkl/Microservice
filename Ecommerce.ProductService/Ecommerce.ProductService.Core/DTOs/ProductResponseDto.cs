namespace Ecommerce.ProductService.Core.DTOs;

public record ProductResponseDto(Guid ProductId, string? ProductName, CategoryOptionDto Category, double? UnitPrice, int? QuantityInStock)
{
    // We need parameter less ctor for the automapper api.
    public ProductResponseDto() : this(default, default, default, default, default) { }
}
