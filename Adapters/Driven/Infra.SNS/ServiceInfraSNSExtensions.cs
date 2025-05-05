using Domain.Ports;
using Infra.SNS.Config;
using Infra.SNS.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.SNS;

public static class ServiceInfraSNSExtensions
{
    public static IServiceCollection AddSNSNotificationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AWSOptions>(configuration.GetSection("AWS:SNS"));
        services.AddTransient<INotificationService, SNSAdapter>();

        return services;
    }
}
