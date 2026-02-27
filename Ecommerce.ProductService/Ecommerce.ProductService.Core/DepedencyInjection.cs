using Ecommerce.ProductService.Core.Mappers;
using Ecommerce.ProductService.Core.ServiceContracts;
using Ecommerce.ProductService.Core.Services;
using Ecommerce.ProductService.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.ProductService.Core;

public static class DepedencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        // Add automapper using the assembly reference.
        services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);

        services.AddScoped<IProductsService, ProductsService>();

        // Add fluent validation to the DI container.
        services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();

        return services;
    }
}
