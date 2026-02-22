using Ecommerce.ProductService.Core.DTOs;
using Ecommerce.ProductService.Core.ServiceContracts;
using FluentValidation;
using FluentValidation.Results;

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
        app.MapGet("/api/products/search/product-id/{productId:guid}", async (IProductsService productService, Guid productId) =>
        {
            ProductResponseDto? product = await productService.GetProductByConditionAsync(p => p.ProductId == productId);
            return Results.Ok(product);
        });

        // GET. /api/products/search/{searchString}
        app.MapGet("/api/products/search/{searchString}", async (IProductsService productService, string searchString) =>
        {
            List<ProductResponseDto?> product = await productService.GetProductsByConditionAsync(p => !string.IsNullOrEmpty(p.ProductName) && p.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            return Results.Ok(product);
        });

        // DELETE. /api/products/{productId}
        app.MapDelete("/api/products/{productId:guid}", async (IProductsService productService, Guid productId) =>
        {
            bool isDeleted = await productService.DeleteProductAsync(productId);

            if (isDeleted) return Results.Ok(true);

            return Results.Problem("Error deleting the product");
        });

        // POST. /api/products
        app.MapPost("/api/products", async (IProductsService productService, IValidator<ProductAddRequestDto> validator, ProductAddRequestDto request) =>
        {
            ValidationResult validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.GroupBy(v => v.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(s => s.ErrorMessage).ToArray());

                return Results.ValidationProblem(errors);
            }

            ProductResponseDto? product = await productService.AddProductAsync(request);

            if (product is not null)
            {
                return Results.Created($"/api/products/search/product-id/{product.ProductId}", product);
            }

            return Results.Problem("Error in adding the product");
        });

        // PUT. /api/products
        app.MapPut("/api/products", async (IProductsService productService, IValidator<ProductUpdateRequestDto> validator, ProductUpdateRequestDto request) =>
        {
            ValidationResult validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.GroupBy(v => v.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(s => s.ErrorMessage).ToArray());

                return Results.ValidationProblem(errors);
            }

            ProductResponseDto? product = await productService.UpdateProductAsync(request);

            if (product is not null)
            {
                return Results.Ok(product);
            }

            return Results.Problem("Error in updating the product");
        });

        return app;
    }
}
