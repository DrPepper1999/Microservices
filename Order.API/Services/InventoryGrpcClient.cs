using Contracts.Inventory.Protobuff.Contracts;
using Contracts.Inventory.Protobuff.Services;
using Grpc.Net.Client;
using Inventory.API.Services.Contracts;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace Order.API.Services;

public class InventoryGrpcClient : IInventoryGrpcClient, IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly GrpcChannel _grpcChannel;
    private readonly IInventoryGrpcService _client;
    
    public InventoryGrpcClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient ??= httpClientFactory.CreateClient("GrpcHttpClient");
        _grpcChannel ??= GrpcChannel.ForAddress("https://localhost:7058", new GrpcChannelOptions { HttpClient = _httpClient });
        _client ??= _grpcChannel.CreateGrpcService<IInventoryGrpcService>();
    }
    
    public Task<CheckConnectionResponse> CheckConnectionAsync(CheckConnectionRequest request, CallContext context = default)
    {
        return _client.CheckConnectionAsync(request, context);
    }

    public Task<GetProductsResponse> GetProductsAsync(GetProductsRequest request, CallContext context = default)
    {
        return _client.GetProductsAsync(request, context);
    }

    public void Dispose()
    {
        _grpcChannel.Dispose();
        _httpClient.Dispose();
    }
}