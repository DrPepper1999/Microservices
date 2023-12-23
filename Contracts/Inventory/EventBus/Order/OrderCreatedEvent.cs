namespace Contracts.Inventory.EventBus.Order;

public record OrderCreatedEvent(OrderHistoryDto Order);

public class OrderHistoryDto
{
    public Guid Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public IEnumerable<ProductHistoryDto>? ProductItems { get; set; }
}
public class ProductHistoryDto
{
    public Guid OrderId { get; set; }
    
    public Guid ProductId { get; set; }

    public string Name { get; set; } = null!;
    
    public int Count { get; set; }
    
    public decimal Price { get; set; }
}
