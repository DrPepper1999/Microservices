using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Order.API.Infrastructure;
using Order.API.Model;
using Order.API.Services.Contracts;

namespace Order.API.Services;

public class OrderService : IOrderService
{
    private readonly IOptions<OrderDBSettings> _options;

    public OrderService(IOptions<OrderDBSettings> orderDbSetting)
    {
        _options = orderDbSetting;
    }

    public async Task<List<OrderItem>> GetAllOrdersAsync()
    {
        var orderCollection = ConnectToMongo<OrderItem>();
        
        return await orderCollection.Find(_ => true).ToListAsync();
    }

    public async Task<OrderItem> GetOrderAsync(Guid id) => await ConnectToMongo<OrderItem>().Find(o => o.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Model.OrderItem order) => await ConnectToMongo<OrderItem>().InsertOneAsync(order);

    public async Task ReplaceAsync(Guid id, Model.OrderItem order) =>
        await ConnectToMongo<OrderItem>().ReplaceOneAsync(o => o.Id == id, order);

    public async Task RemoveAsync(Guid id) => await ConnectToMongo<OrderItem>().DeleteOneAsync(o => o.Id == id);

    private IMongoCollection<T> ConnectToMongo<T>()
        where T: IMongoEntity
    {
        var mongoClient = new MongoClient(_options.Value.ConnectionString);

        var orderDatabase = mongoClient.GetDatabase(_options.Value.DatabaseName);

        return orderDatabase.GetCollection<T>(T.CollectionName);
    }
}