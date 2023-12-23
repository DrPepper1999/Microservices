using Inventory.API.Model;

namespace Inventory.API.Services.Contracts;

public interface IInventoryService
{
    Task<IEnumerable<ProductsDto>> GetProductsAsync(IEnumerable<Guid> ids);
}