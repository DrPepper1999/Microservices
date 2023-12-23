using Order.API.Model;

namespace Order.API.Services;

public interface IOrderRepository
{
    Task<List<OrderItem>> GetAllOrdersAsync();
    Task CreateAsync(Model.OrderItem order);
    Task ReplaceAsync(Guid id, Model.OrderItem order);
    Task RemoveAsync(Guid id);
    Task<OrderItem> GetOrderAsync(Guid id);
}