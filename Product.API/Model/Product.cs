namespace Product.API.Model;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Weight { get; set; }
    
    public string Description { get; set; } = null!;
}