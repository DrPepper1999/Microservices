using Contracts.Inventory.EventBus.Order;
using MongoDB.Driver;
using Notification.API.Infrastructure;
using Notification.API.Model;
using Notification.API.Services.Contracts;

namespace Notification.API.Services;

public class NotificationService : INotificationService
{
    private readonly DBSettings _options;

    public NotificationService(DBSettings options)
    {
        _options = options;
    }

    public async Task<Guid> Create(OrderHistoryDto orderHistoryDto)
    {
        var orderHistory = new OrderHistory()
        {
            Id = orderHistoryDto.Id,
            Date = orderHistoryDto.Date,
            ProductItems = orderHistoryDto.ProductItems
                .Select(p => new ProductHistory
            {
                OrderId = p.OrderId,
                Name = p.Name,
                Count = p.Count,
                Price = p.Price,
                ProductId = p.ProductId
            }).ToList()
        };

        await ConnectToMongo<OrderHistory>().InsertOneAsync(orderHistory);

        return orderHistory.Id;
    }

    private IMongoCollection<T> ConnectToMongo<T>()
        where T: IMongoEntity
    {
        var mongoClient = new MongoClient(_options.ConnectionString);

        var orderDatabase = mongoClient.GetDatabase(_options.DatabaseName);

        return orderDatabase.GetCollection<T>(T.CollectionName);
    }
}