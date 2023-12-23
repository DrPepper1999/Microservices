using System.Runtime.Serialization;

namespace Contracts.Inventory.Protobuff.Contracts;

[DataContract]
public class GetProductsResponse
{
    [DataMember(Order = 1)]
    public IEnumerable<ProductResponse> Products { get; set; } = new List<ProductResponse>();
}