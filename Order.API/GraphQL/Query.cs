using Order.API.Model;
using Order.API.Services;

namespace Order.API.GraphQL;

public class Query
{
     public async Task<ICollection<OrderItem>> GetOrders([Service] OrderService orderService)
     {
         return (await orderService.Get()).ToList();
     }
}