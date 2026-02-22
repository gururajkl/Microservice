using Ecommerce.ProductService.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.ProductService.Core;

public static class DepedencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        // Add automapper using the assembly reference.
        services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);

        return services;
    }
}
