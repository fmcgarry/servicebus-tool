using ServiceBusTool.Core.Models;

namespace ServiceBusTool.Core.Interfaces;

public interface IServiceBusClient
{
    Task<IEnumerable<Subscription>> GetSubscriptionsAsync(string @namespace, string topic);

    Task<IEnumerable<Topic>> GetTopicsAsync(string @namespace);
}