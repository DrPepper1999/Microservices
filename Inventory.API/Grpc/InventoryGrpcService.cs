using Contracts.Inventory.Protobuff.Contracts;
using Contracts.Inventory.Protobuff.Services;
using Inventory.API.Services.Contracts;
using ProtoBuf.Grpc;

namespace Inventory.API.Grpc;

public class InventoryGrpcService : IInventoryGrpcService
{

    private readonly IInventoryService _inventoryService;
    
    public InventoryGrpcService(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    
    public Task<CheckConnectionResponse> CheckConnectionAsync(CheckConnectionRequest request, CallContext context = default)
    {
        return Task.FromResult(new CheckConnectionResponse());
    }

    public async Task<GetProductsResponse> GetProductsAsync(GetProductsRequest request,
        CallContext context = default)
    {
        var products = await _inventoryService.GetProductsAsync(request.Ids);

        return new GetProductsResponse()
        {
            Products = products.Select(p => new ProductResponse()
            {
                Id = p.Id,
                Name = p.Name,
                Count = p.Count,
                Price = p.Price
            })
        };
    }
}