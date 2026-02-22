namespace Ecommerce.ProductService.Core.DTOs;

/// <summary>
/// Data transfer object used for updating an existing product's information.
/// </summary>
/// <param name="ProductId">The unique identifier of the product to be updated.</param>
/// <param name="ProductName">The updated name of the product.</param>
/// <param name="Category">The updated category classification.</param>
/// <param name="UnitPrice">The updated price per unit.</param>
/// <param name="QuantityInStock">The updated stock level.</param>
public record ProductUpdateRequestDto(Guid ProductId, string? ProductName, CategoryOptionDto Category, double? UnitPrice, int? QuantityInStock)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductUpdateRequestDto"/> record.
    /// Required for mapping frameworks like AutoMapper.
    /// </summary>
    public ProductUpdateRequestDto() : this(default, default, default, default, default) { }
}
