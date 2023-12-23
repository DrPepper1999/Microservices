using MongoDB.Bson.Serialization.Attributes;
using Notification.API.Services.Contracts;

namespace Notification.API.Model;

public class OrderHistory : IMongoEntity
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid Id { get; set; }
    
    public DateTime Date { get; set; }
    
    public ICollection<ProductHistory>? ProductItems { get; set; }
    
    public static string CollectionName => nameof(OrderHistory);
}