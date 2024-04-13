using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;
using ServiceBusTool.Core.ServiceBus.Interfaces;
using ServiceBusTool.Core.ServiceBus.Models;
using System.Text;

namespace ServiceBusTool.Infrastructure.ServiceBus;

public class ServiceBusToolClient(ILogger<ServiceBusToolClient> logger, IAzureClientFactory<ServiceBusClient> clientFactory, IAzureClientFactory<ServiceBusAdministrationClient> adminClientFactory) : IServiceBusClient
{
    public async Task<IReadOnlyList<ServiceBusReceivedMessage>> GetDlqMessages(string @namespace, string topic, string subscription)
    {
        logger.LogInformation("Getting dlq messages for {namespace} {topic} {subscription}", @namespace, topic, subscription);

        var client = clientFactory.CreateClient(@namespace);
        var adminClient = adminClientFactory.CreateClient(@namespace);

        var rawSubscription = (await adminClient.GetSubscriptionRuntimePropertiesAsync(topic, subscription)).Value;
        int numMessages = Convert.ToInt32(rawSubscription.DeadLetterMessageCount);

        var serviceBusReceiver = client.CreateReceiver(topic, subscription, new ServiceBusReceiverOptions() { SubQueue = SubQueue.DeadLetter });

        IReadOnlyList<ServiceBusReceivedMessage> messages = await serviceBusReceiver.PeekMessagesAsync(numMessages);

        logger.LogDebug("Found {numDlqMessages} for {namespace}/{topic}/{subscription}", messages.Count, @namespace, topic, subscription);

        return messages;
    }

    public async Task<IEnumerable<Topic>> GetTopicsAsync(string @namespace)
    {
        logger.LogInformation("Getting topics for {namespace} ", @namespace);

        var topics = new List<Topic>();

        var adminClient = adminClientFactory.CreateClient(@namespace);
        var rawTopics = adminClient.GetTopicsAsync();

        await foreach (var rawTopic in rawTopics)
        {
            var topic = new Topic()
            {
                Name = rawTopic.Name,
            };

            topics.Add(topic);
        }

        logger.LogDebug("Found {numTopics} topics in {namespace}", topics.Count, @namespace);

        return topics;
    }

    public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync(string @namespace, string topic)
    {
        logger.LogInformation("Getting subscriptions for {namespace}/{topic}", @namespace, topic);

        var subscriptions = new List<Subscription>();

        var adminClient = adminClientFactory.CreateClient(@namespace);
        var rawSubscriptions = adminClient.GetSubscriptionsRuntimePropertiesAsync(topic);

        await foreach (var rawSuscription in rawSubscriptions)
        {

            var subscription = new Subscription()
            {
                Name = rawSuscription.SubscriptionName,
                NumActiveMessages = Convert.ToInt32(rawSuscription.ActiveMessageCount),
                NumDlqMessages = Convert.ToInt32(rawSuscription.DeadLetterMessageCount)
            };

            subscriptions.Add(subscription);
        }

        logger.LogDebug("Found {numSubscriptions} subscriptions in {namespace}/{topic}", subscriptions.Count, @namespace, topic);

        return subscriptions;
    }

    public string GetStringFromMessageBody(BinaryData messageBody)
    {
        var content = Encoding.UTF8.GetString(messageBody);

        // If there's a BOM the Parse will fail.
        string bom = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
        content = content.Trim(bom.ToCharArray());

        return content;
    }
}
