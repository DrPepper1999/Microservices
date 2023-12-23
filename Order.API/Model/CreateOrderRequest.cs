namespace Order.API.Model;

public record CreateOrderRequest(IEnumerable<Guid> productIds);