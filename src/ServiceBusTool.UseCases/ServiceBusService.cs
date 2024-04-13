using ServiceBusTool.Core.Interfaces;
using ServiceBusTool.Core.Models;

namespace ServiceBusTool.UseCases;

public class ServiceBusService(IServiceBusClient _serviceBusClient) : IServiceBusService
{
    public void GetAllDlqMessages(string subscriptionName)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync(string namespaceName, string topicName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(namespaceName);
        ArgumentException.ThrowIfNullOrWhiteSpace(topicName);

        var subscriptions = await _serviceBusClient.GetSubscriptionsAsync(namespaceName, topicName);

        return subscriptions;
    }

    public async Task<IEnumerable<Topic>> GetAllTopicsAsync(string namespaceName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(namespaceName);

        var topics = await _serviceBusClient.GetTopicsAsync(namespaceName);

        return topics;
    }

    public void GetDlqMessagesFrom(int sequenceId, string subscriptionName)
    {
        throw new NotImplementedException();
    }
}