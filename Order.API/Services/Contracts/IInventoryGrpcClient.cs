using System.ServiceModel;
using Contracts.Inventory.Protobuff.Contracts;
using ProtoBuf.Grpc;

namespace Inventory.API.Services.Contracts;

public interface IInventoryGrpcClient
{
    [OperationContract] 
    Task<CheckConnectionResponse> CheckConnectionAsync(CheckConnectionRequest request, CallContext context = default);
    
    [OperationContract]
    Task<GetProductsResponse> GetProductsAsync(GetProductsRequest request,
        CallContext context = default);
}