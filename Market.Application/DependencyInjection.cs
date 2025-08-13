using Market.Application.Interfaces;
using Market.Application.Mapping;
using Market.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<JwtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<PasswordService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IProduceService, ProduceService>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddScoped<IProduceVariantService, ProduceVariantService>();

        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }
}