using Ecommerce.ProductService.Core.DTOs;
using Ecommerce.ProductService.Infrastructure.Entities;
using System.Linq.Expressions;

namespace Ecommerce.ProductService.Core.ServiceContracts;

public interface IProductsService
{
    Task<ProductResponseDto?> GetProductsAsync();
    Task<List<ProductResponseDto?>> GetProductsByConditionAsync(Expression<Func<Product, bool>> expression);
    Task<ProductResponseDto?> GetProductByConditionAsync(Expression<Func<Product, bool>> expression);
    Task<ProductResponseDto?> AddProductAsync(ProductAddRequestDto productAddRequestDto);
    Task<ProductResponseDto?> UpdateProductAsync(ProductUpdateRequestDto productUpdateRequestDto);
    Task<bool> DeleteProductAsync(Guid productId);
}
