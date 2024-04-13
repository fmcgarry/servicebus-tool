using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBusTool.Core.Interfaces;
using ServiceBusTool.Infrastructure;

namespace ServiceBusTool.UseCases;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceBusService(this IServiceCollection services, IConfiguration namedConfigurationSection)
    {
        services.AddServiceBusClients(namedConfigurationSection);
        services.AddScoped<IServiceBusService, ServiceBusService>();

        return services;
    }
}
