namespace ServiceBusTool.Infrastructure;

public class ServiceBusClientOptions
{
    public string Namespace { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}
