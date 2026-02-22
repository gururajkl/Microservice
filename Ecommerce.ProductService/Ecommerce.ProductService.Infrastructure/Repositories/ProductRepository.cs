using Ecommerce.ProductService.Infrastructure.DatabaseContext;
using Ecommerce.ProductService.Infrastructure.Entities;
using Ecommerce.ProductService.Infrastructure.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.ProductService.Infrastructure.Repositories;

internal class ProductRepository(ProductDbContext dbContext) : IProductsRepository
{
    public async Task<Product?> AddProduct(Product product)
    {
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        Product? product = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

        if (product is null) return false;

        dbContext.Products.Remove(product);
        int rowsDeleted = await dbContext.SaveChangesAsync();

        return rowsDeleted > 0;
    }

    public async Task<Product?> GetProductByConditionAsync(Expression<Func<Product, bool>> expression)
    {
        return await dbContext.Products.FirstOrDefaultAsync(expression);
    }

    public async Task<IEnumerable<Product>?> GetProductsByConditionAsync(Expression<Func<Product, bool>> expression)
    {
        return await dbContext.Products.Where(expression).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await dbContext.Products.ToListAsync();
    }

    public async Task<Product?> UpdateProduct(Product product)
    {
        Product? exisitingProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

        if (exisitingProduct is null) return null;

        exisitingProduct.ProductName = product.ProductName;
        exisitingProduct.UnitPrice = product.UnitPrice;
        exisitingProduct.QuantityInStock = product.QuantityInStock;
        exisitingProduct.Category = product.Category;

        await dbContext.SaveChangesAsync();

        return exisitingProduct;
    }
}
