using ServiceBusTool.Core.ServiceBus.Models;

namespace ServiceBusTool.Core.ServiceBus.Interfaces;

public interface IServiceBusClient
{
    Task<IEnumerable<Subscription>> GetSubscriptionsAsync(string @namespace, string topic);
    Task<IEnumerable<Topic>> GetTopicsAsync(string @namespace);
}
