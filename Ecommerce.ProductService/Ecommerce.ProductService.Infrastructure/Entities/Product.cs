using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ProductService.Infrastructure.Entities;

/// <summary>
/// Represents a product entity within the Ecommerce system.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    [Key]
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category the product belongs to.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price per unit.
    /// </summary>
    public double? UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the current stock level.
    /// </summary>
    public int? QuantityInStock { get; set; }
}