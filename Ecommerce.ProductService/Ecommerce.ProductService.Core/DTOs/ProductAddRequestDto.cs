namespace Ecommerce.ProductService.Core.DTOs;

public record ProductAddRequestDto(string? ProductName, CategoryOptionDto Category, double? UnitPrice, int? QuantityInStock)
{
    // We need parameter less ctor for the automapper api.
    public ProductAddRequestDto() : this(default, default, default, default) { }
}
