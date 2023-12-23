namespace Notification.API.Infrastructure;

public class DBSettings
{
    public string ConnectionString { get; set; } = null!;
    
    public string DatabaseName { get; set; } = null!;
    
    public string OrderCollectionName { get; set; } = null!;
    
    
    public string ProductItemCollectionName { get; set; } = null!;
    
    public static string SectionName { get; } = "Database";
}