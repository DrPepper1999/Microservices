namespace Inventory.API.Model;

public class ProductsDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    
    public int Count { get; set; }
    
    public decimal Price { get; set; }
}
