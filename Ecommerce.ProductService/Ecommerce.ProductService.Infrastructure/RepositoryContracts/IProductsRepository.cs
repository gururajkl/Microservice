using Ecommerce.ProductService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace Ecommerce.ProductService.Infrastructure.RepositoryContracts;

/// <summary>
/// Defines the data access operations for <see cref="Product"/> entities.
/// </summary>
public interface IProductsRepository
{
    /// <summary>
    /// Retrieves all products from the database.
    /// </summary>
    Task<IEnumerable<Product>> GetProductsAsync();

    /// <summary>
    /// Retrieves a list of products that match a specific condition.
    /// </summary>
    /// <param name="expression">The filter logic to apply.</param>
    Task<IEnumerable<Product>?> GetProductsByConditionAsync(Expression<Func<Product, bool>> expression);

    /// <summary>
    /// Retrieves a single product that matches a specific condition.
    /// </summary>
    /// <param name="expression">The filter logic to apply.</param>
    Task<Product?> GetProductByConditionAsync(Expression<Func<Product, bool>> expression);

    /// <summary>
    /// Adds a new product to the database.
    /// </summary>
    /// <param name="product">The product data to insert.</param>
    Task<Product?> AddProduct(Product product);

    /// <summary>
    /// Updates an existing product in the database.
    /// </summary>
    /// <param name="product">The product data to update.</param>
    Task<Product?> UpdateProduct(Product product);

    /// <summary>
    /// Deletes a product from the database by its unique ID.
    /// </summary>
    /// <param name="productId">The ID of the product to remove.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteProduct(Guid productId);
}