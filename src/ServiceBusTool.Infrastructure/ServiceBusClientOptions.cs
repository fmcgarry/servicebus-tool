namespace ServiceBusTool.Infrastructure;

public class ServiceBusClientOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public string Namespace { get; set; } = string.Empty;
}