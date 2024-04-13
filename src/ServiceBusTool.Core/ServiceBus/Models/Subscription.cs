namespace ServiceBusTool.Core.ServiceBus.Models;

public class Subscription
{
    public string Name { get; set; } = string.Empty;
    public int NumActiveMessages { get; set; }
    public int NumDlqMessages { get; set; }
}
