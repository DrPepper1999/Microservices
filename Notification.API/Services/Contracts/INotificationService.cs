using Contracts.Inventory.EventBus.Order;

namespace Notification.API.Services.Contracts;

public interface INotificationService
{
    Task<Guid> Create(OrderHistoryDto orderHistoryDto);
}