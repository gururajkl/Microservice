using Ecommerce.ProductService.Core.DTOs;
using Ecommerce.ProductService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace Ecommerce.ProductService.Core.ServiceContracts;

/// <summary>
/// Defines business logic operations for managing products.
/// </summary>
public interface IProductsService
{
    /// <summary>
    /// Retrieves all products and returns them as DTOs.
    /// </summary>
    Task<List<ProductResponseDto?>> GetProductsAsync();

    /// <summary>
    /// Filters products based on a specific condition and returns a list of matches.
    /// </summary>
    /// <param name="expression">The business logic filter to apply.</param>
    Task<List<ProductResponseDto?>> GetProductsByConditionAsync(Expression<Func<Product, bool>> expression);

    /// <summary>
    /// Finds a single product matching a condition and returns it as a DTO.
    /// </summary>
    /// <param name="expression">The business logic filter to apply.</param>
    Task<ProductResponseDto?> GetProductByConditionAsync(Expression<Func<Product, bool>> expression);

    /// <summary>
    /// Processes the request to create a new product.
    /// </summary>
    /// <param name="productAddRequestDto">The data required to create a product.</param>
    Task<ProductResponseDto?> AddProductAsync(ProductAddRequestDto productAddRequestDto);

    /// <summary>
    /// Processes the request to update an existing product.
    /// </summary>
    /// <param name="productUpdateRequestDto">The updated product data.</param>
    Task<ProductResponseDto?> UpdateProductAsync(ProductUpdateRequestDto productUpdateRequestDto);

    /// <summary>
    /// Removes a product from the system by its unique ID.
    /// </summary>
    /// <param name="productId">The ID of the product to delete.</param>
    /// <returns>True if the operation succeeded otherwise, false.</returns>
    Task<bool> DeleteProductAsync(Guid productId);
}