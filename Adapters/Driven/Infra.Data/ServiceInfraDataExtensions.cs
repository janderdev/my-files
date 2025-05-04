using Domain.Adapters;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data;

public static class ServiceInfraDataExtensions
{
    public static IServiceCollection AddDataBaseService(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<SqlContext>(option => option.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
