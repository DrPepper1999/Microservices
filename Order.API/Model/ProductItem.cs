using MongoDB.Bson.Serialization.Attributes;
using Order.API.Services;
using Order.API.Services.Contracts;

namespace Order.API.Model;

public class ProductItem : IMongoEntity
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid OrderId { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid ProductId { get; set; }

    public string Name { get; set; } = null!;
    
    public int Count { get; set; }
    
    public decimal Price { get; set; }
    public static string CollectionName => nameof(ProductItem);
}