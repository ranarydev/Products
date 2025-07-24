using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Interfaces;
using Products.Infrastructure.Repositories;

namespace Products.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddProductsApplicationLayer(this IServiceCollection services)
    {

        services.AddScoped<IProductsRepository, ProductsRepository>();

        return services;
    }
}
