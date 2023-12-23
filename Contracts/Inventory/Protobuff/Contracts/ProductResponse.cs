using System.Runtime.Serialization;

namespace Contracts.Inventory.Protobuff.Contracts;

[DataContract]
public class ProductResponse
{
    [DataMember(Order = 1)]
    public Guid Id { get; set; }

    [DataMember(Order = 2)]
    public string Name { get; set; } = null!;
    
    [DataMember(Order = 3)]
    public int Count { get; set; }
    
    [DataMember(Order = 4)]
    public decimal Price { get; set; }
}