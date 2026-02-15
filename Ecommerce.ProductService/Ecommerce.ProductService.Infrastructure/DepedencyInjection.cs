using Ecommerce.ProductService.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.ProductService.Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PersonDbContext>(options =>
        {
            options.UseMySQL(configuration.GetConnectionString("MySQL")!);
        });

        return services;
    }
}
