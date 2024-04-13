using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceBusTool.Core.Interfaces;

namespace ServiceBusTool.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceBusClients(this IServiceCollection services, IConfiguration namedConfigurationSection)
    {
        var sectionChildren = namedConfigurationSection.GetChildren();
        foreach (var item in sectionChildren)
        {
            var serviceBusClientOptions = new ServiceBusClientOptions();
            item.Bind(serviceBusClientOptions);

            services.Configure<ServiceBusClientOptions>(item.Key, item);

            services.AddAzureClients(builder =>
            {
                builder.AddServiceBusClient(serviceBusClientOptions.ConnectionString).WithName(item.Key);
                builder.AddServiceBusAdministrationClient(serviceBusClientOptions.ConnectionString).WithName(item.Key);
                builder.UseCredential(new DefaultAzureCredential());
            });
        }

        services.AddScoped<IServiceBusClient, ServiceBusToolClient>();

        return services;
    }
}
