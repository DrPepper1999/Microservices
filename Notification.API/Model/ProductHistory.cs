using MongoDB.Bson.Serialization.Attributes;
using Notification.API.Services.Contracts;

namespace Notification.API.Model;

public class ProductHistory : IMongoEntity
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid OrderId { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid ProductId { get; set; }

    public string Name { get; set; } = null!;
    
    public int Count { get; set; }
    
    public decimal Price { get; set; }
    
    public static string CollectionName => nameof(ProductHistory);
}