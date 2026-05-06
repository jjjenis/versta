using Application.Abstractions.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        string? connectionString)
    {
        collection.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        collection.AddScoped<IOrderRepository, OrderRepository>();

        return collection;
    }
}
