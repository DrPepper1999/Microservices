using Order.API.Model;

namespace Order.API.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderItem>> Get()
    {
        return await _orderRepository.GetAllOrdersAsync();
    }
}