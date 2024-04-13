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
        return await _serviceBusClient.GetSubscriptionsAsync(namespaceName, topicName);
    }

    public async Task<IEnumerable<Topic>> GetAllTopicsAsync(string namespaceName)
    {
        return await _serviceBusClient.GetTopicsAsync(namespaceName);
    }

    public void GetDlqMessagesFrom(int sequenceId, string subscriptionName)
    {
        throw new NotImplementedException();
    }
}