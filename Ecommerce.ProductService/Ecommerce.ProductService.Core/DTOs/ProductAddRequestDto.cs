namespace Ecommerce.ProductService.Core.DTOs;

/// <summary>
/// Data transfer object used for requesting the creation of a new product.
/// </summary>
/// <param name="ProductName">The name of the product to be created.</param>
/// <param name="Category">The category option selected for this product.</param>
/// <param name="UnitPrice">The initial price per unit.</param>
/// <param name="QuantityInStock">The initial stock count available.</param>
public record ProductAddRequestDto(string? ProductName, CategoryOptionDto Category, double? UnitPrice, int? QuantityInStock)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductAddRequestDto"/> record.
    /// Required for frameworks like AutoMapper.
    /// </summary>
    public ProductAddRequestDto() : this(default, default, default, default) { }
}
