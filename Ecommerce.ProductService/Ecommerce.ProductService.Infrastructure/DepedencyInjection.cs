using Ecommerce.ProductService.Infrastructure.DatabaseContext;
using Ecommerce.ProductService.Infrastructure.Repositories;
using Ecommerce.ProductService.Infrastructure.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.ProductService.Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductDbContext>(options =>
        {
            options.UseMySQL(configuration.GetConnectionString("MySQL")!);
        });

        services.AddScoped<IProductsRepository, ProductRepository>();

        return services;
    }
}
