using Ecommerce.Core.RepositoryContracts;
using Ecommerce.Infrastructure.DbContext;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to which infrastructure services will be added. Cannot be null.</param>
    /// <returns>The service collection with the infrastructure services registered.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();
        return services;
    }
}
