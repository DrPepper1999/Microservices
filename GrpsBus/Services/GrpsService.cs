using Contracts.Protobuff.Contracts;
using Contracts.Protobuff.Services;
using ProtoBuf.Grpc;

namespace GrpsBus;

public class GrpsService : IGrpsService
{
    public Task<CheckConnectionResponse> CheckConnectionAsync(CheckConnectionRequest request, CallContext context = default)
    {
        return Task.FromResult(new CheckConnectionResponse());
    }
}