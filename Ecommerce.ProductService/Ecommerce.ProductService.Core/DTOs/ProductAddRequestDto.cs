namespace Ecommerce.ProductService.Core.DTOs;

public record ProductAddRequestDto(string? ProductName, CategoryOptionDto CategoryOption, double? UnitPrice, int? Quantity)
{
    // We need parameter less ctor for the automapper api.
    public ProductAddRequestDto() : this(default, default, default, default) { }
}
