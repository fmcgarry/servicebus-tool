using ServiceBusTool.Core.Models;

namespace ServiceBusTool.Core.Interfaces
{
    public interface IServiceBusService
    {
        void GetAllDlqMessages(string subscription);
        Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync(string @namespace, string topic);
        Task<IEnumerable<Topic>> GetAllTopicsAsync(string @namespace);
        void GetDlqMessagesFrom(int sequenceId, string subscription);
    }
}