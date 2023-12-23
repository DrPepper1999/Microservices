using System.Runtime.Serialization;

namespace Contracts.Inventory.Protobuff.Contracts;

[DataContract]
public class CheckConnectionResponse
{ 
    [DataMember(Order = 1)]
    public int? ErrorCode { get; set; }
    
    [DataMember(Order = 2)]
    public string ErrorDescription { get; set; } = string.Empty;
}