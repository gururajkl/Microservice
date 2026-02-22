using Ecommerce.ProductService.Core.Mappers;
using Ecommerce.ProductService.Core.ServiceContracts;
using Ecommerce.ProductService.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.ProductService.Core;

public static class DepedencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        // Add automapper using the assembly reference.
        services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);

        services.AddScoped<IProductsService, ProductsService>();

        return services;
    }
}
