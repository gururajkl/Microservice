using Ecommerce.ProductService.Core.DTOs;
using Ecommerce.ProductService.Core.ServiceContracts;

namespace Ecommerce.ProductService.API.APIEndpoints;

public static class ProductAPIEndpoint
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        // GET. /api/products
        app.MapGet("/api/products", async (IProductsService productsService) =>
        {
            List<ProductResponseDto?> products = await productsService.GetProductsAsync();
            return Results.Ok(products);
        });

        // GET. /api/products/search/product-id/{productId}
        app.MapGet("/api/products/search/product-id/{productId}", async (IProductsService productService, Guid productId) =>
        {
            ProductResponseDto? product = await productService.GetProductByConditionAsync(p => p.ProductId == productId);
            return Results.Ok(product);
        });

        // GET. /api/products/search/{searchString}
        app.MapGet("/api/products/search/{searchString}", async (IProductsService productService, string searchString) =>
        {
            ProductResponseDto? product = await productService.GetProductByConditionAsync(p => p.ProductName == searchString);
            return Results.Ok(product);
        });

        // DELETE. /api/products/{productId}
        app.MapDelete("/api/products/{productId}", async (IProductsService productService, Guid productId) =>
        {
            bool result = await productService.DeleteProductAsync(productId);
            return Results.Ok(result);
        });

        // POST. /api/products
        app.MapPost("/api/products", async (IProductsService productService, ProductAddRequestDto request) =>
        {
            ProductResponseDto? product = await productService.AddProductAsync(request);
            return Results.Ok(product);
        });

        // PUT. /api/products
        app.MapPut("/api/products", async (IProductsService productService, ProductUpdateRequestDto request) =>
        {
            ProductResponseDto? product = await productService.UpdateProductAsync(request);
            return Results.Ok(product);
        });

        return app;
    }
}
