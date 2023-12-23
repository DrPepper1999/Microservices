using MongoDB.Bson.Serialization.Attributes;
using Order.API.Services;
using Order.API.Services.Contracts;

namespace Order.API.Model;

public class OrderItem : IMongoEntity
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public ICollection<ProductItem>? ProductItems { get; set; }
    
    public static string CollectionName => nameof(OrderItem);
}