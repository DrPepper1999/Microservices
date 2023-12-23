using Contracts.Inventory.EventBus.Order;
using MassTransit;
using Notification.API.Services.Contracts;

namespace Notification.API.Services;

public class OrderCreatedEventHandler : IConsumer<OrderCreatedEvent>
{
    private readonly INotificationService _notificationService;
    
    public OrderCreatedEventHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    
    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        await _notificationService.Create(context.Message.Order);
    }
}