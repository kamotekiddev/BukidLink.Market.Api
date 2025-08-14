using Market.Application.Interfaces;
using Market.Infrastructure.Context;
using Market.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRolesRepository, UserRolesRespository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IProduceRepository, ProduceRepository>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IProduceVariantRepository, ProduceVariantRepository>();
        services.AddScoped<IProduceCategoryRepository, ProduceCategoryRepository>();

        return services;
    }
}