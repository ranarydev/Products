using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddProductsInfrastructureLayer(this IServiceCollection services)
    {
        // Connection to the schema: productsdb
        string connectionString = "Server=localhost;Port=3306;Database=productsdb;Uid=root;Pwd=admin;";
        services.AddDbContext<ProductsDbContext>(options => {
            options.UseMySQL(connectionString);
        });
        return services;
    }
}
