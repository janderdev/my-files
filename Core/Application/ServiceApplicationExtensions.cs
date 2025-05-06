using Application.Services;
using Domain.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceApplicationExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    }
}
