namespace Order.API.Infrastructure;

public class OrderDBSettings
{
    public string ConnectionString { get; set; } = null!;
    
    public string DatabaseName { get; set; } = null!;
    
    public string OrderCollectionName { get; set; } = null!;
    
    
    public string ProductItemCollectionName { get; set; } = null!;
    
    public static string SectionName { get; } = "OrderDB";
}