namespace Inventory.API.Model;

public class Inventory
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    
    public string Name { get; set; } = null!;

    public int Count { get; set; }
    
    public decimal Price { get; set; }
}