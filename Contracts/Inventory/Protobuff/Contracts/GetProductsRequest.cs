using System.Runtime.Serialization;

namespace Contracts.Inventory.Protobuff.Contracts;

[DataContract]
public class GetProductsRequest
{
    [DataMember(Order = 1)] 
    public IEnumerable<Guid> Ids { get; set; } = new List<Guid>();
}