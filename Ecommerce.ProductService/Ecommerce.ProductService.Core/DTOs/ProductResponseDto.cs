namespace Ecommerce.ProductService.Core.DTOs;

/// <summary>
/// Data transfer object representing a product's details in a response.
/// </summary>
/// <param name="ProductId">The unique identifier of the product.</param>
/// <param name="ProductName">The name of the product.</param>
/// <param name="Category">The category classification of the product.</param>
/// <param name="UnitPrice">The current price per unit.</param>
/// <param name="QuantityInStock">The current quantity available in inventory.</param>
public record ProductResponseDto(Guid ProductId, string? ProductName, CategoryOptionDto Category, double? UnitPrice, int? QuantityInStock)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductResponseDto"/> record.
    /// Required for mapping frameworks like AutoMapper.
    /// </summary>
    public ProductResponseDto() : this(default, default, default, default, default) { }
}
