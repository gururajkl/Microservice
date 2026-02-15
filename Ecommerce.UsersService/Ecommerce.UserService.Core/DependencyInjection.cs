using Ecommerce.Core.ServiceContracts;
using Ecommerce.Core.Services;
using Ecommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to which core services will be added. Cannot be null.</param>
    /// <returns>The service collection with the core services registered.</returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();

        // Add all the fluent validators.
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}
