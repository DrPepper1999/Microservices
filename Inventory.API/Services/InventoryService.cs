using Inventory.API.Infrastructure;
using System.Linq;
using Inventory.API.Model;
using Inventory.API.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Services;

public class InventoryService : IInventoryService
{

    private readonly InventoryContext _context;
    
    public InventoryService(InventoryContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProductsDto>> GetProductsAsync(IEnumerable<Guid> ids)
    {
        var products =  await _context.Products
            .Where(i => ids.Contains(i.ProductId))
            .ToListAsync();

        return products.Select(p => new ProductsDto()
        {
            Id = p.ProductId,
            Name = p.Name,
            Count = p.Count,
            Price = p.Price
        });
    }
}