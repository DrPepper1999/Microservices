using System.ServiceModel;
using Contracts.Inventory.Protobuff.Contracts;
using ProtoBuf.Grpc;

namespace Contracts.Inventory.Protobuff.Services;

[ServiceContract]
public interface IInventoryGrpcService
{
    [OperationContract]
    Task<CheckConnectionResponse> CheckConnectionAsync(CheckConnectionRequest request, CallContext context = default);

    [OperationContract]
    Task<GetProductsResponse> GetProductsAsync(GetProductsRequest request,
        CallContext context = default);
}