using ServiceBusTool.Core.Interfaces;
using ServiceBusTool.Core.Models;

namespace ServiceBusTool.UseCases;

public class ServiceBusService(IServiceBusClient _serviceBusClient) : IServiceBusService
{
    public async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync(string @namespace, string topic)
    {
        return await _serviceBusClient.GetSubscriptionsAsync(@namespace, topic);
    }

    public async Task<IEnumerable<Topic>> GetAllTopicsAsync(string @namespace)
    {
        return await _serviceBusClient.GetTopicsAsync(@namespace);
    }

    public void GetAllDlqMessages(string subscription)
    {

    }

    public void GetDlqMessagesFrom(int sequenceId, string subscription)
    {

    }
}
