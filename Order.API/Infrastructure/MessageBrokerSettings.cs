namespace Order.API.Infrastructure;

public class MessageBrokerSettings
{
    public string Host { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;

    public static string SectionName { get; set; } = "MessageBroker";
}