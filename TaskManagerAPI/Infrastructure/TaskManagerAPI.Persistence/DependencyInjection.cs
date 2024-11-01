using Microsoft.Extensions.DependencyInjection;
using TaskManagerAPI.Application.Common.Interfaces;
using TaskManagerAPI.Persistence.Services;

namespace TaskManagerAPI.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        return services;
    }
}
