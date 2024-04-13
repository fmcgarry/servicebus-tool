using ServiceBusTool.Core.Models;

namespace ServiceBusTool.Core.Interfaces
{
    public interface IServiceBusService
    {
        void GetAllDlqMessages(string subscriptionName);

        Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync(string namespaceName, string topicName);

        Task<IEnumerable<Topic>> GetAllTopicsAsync(string namespaceName);

        void GetDlqMessagesFrom(int sequenceId, string subscriptionName);
    }
}