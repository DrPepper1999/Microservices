using Contracts.Inventory.EventBus.Order;
using Contracts.Inventory.Protobuff.Contracts;
using Inventory.API.Services.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Order.API.Model;
using Order.API.Services;

namespace Order.API.Apis;

public static class OrderApi
{
    public static IEndpointRouteBuilder MapOrderApi(this IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", CreateOrder);
        app.MapGet("/orders", GetAllOrders);
        app.MapGet("/orders/{id}", GetOrder);
        app.MapDelete("/orders", DeleteOrder);

        app.MapGet("/inventory/cheack", Cheack);

        return app;
    }

    private static async Task<Results<Ok<Guid>, ProblemHttpResult>> CreateOrder(CreateOrderRequest request, IOrderRepository orderRepository, IInventoryGrpcClient inventoryGrpcClient, IPublishEndpoint publishEndpoint)
    {
        var products = (await inventoryGrpcClient
            .GetProductsAsync(new GetProductsRequest { Ids = request.productIds }))
            .Products.ToList();

        if (products.Any(p => p.Count == 0))
        {
            return TypedResults.Problem(statusCode: StatusCodes.Status409Conflict, title: "Одного из выбранных товаров нет в наличие");
        }
        
        var order = new OrderItem()
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            ProductItems = products
                .Select(p => new ProductItem()
                {
                    OrderId = Guid.NewGuid(),
                    ProductId = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Count = p.Count
                })
                .ToList()
        };

        await orderRepository.CreateAsync(order);

        await publishEndpoint.Publish(new OrderCreatedEvent(new OrderHistoryDto()
        {
            Id = order.Id,
            Date = order.Date,
            ProductItems = order.ProductItems.Select(p => new ProductHistoryDto()
            {
                OrderId = p.OrderId,
                Name = p.Name,
                Price = p.Price,
                Count = p.Count,
                ProductId = p.ProductId
            })
        }));
        
        return TypedResults.Ok(order.Id);
    }

    private static async Task<Ok<List<OrderItem>>> GetAllOrders(IOrderRepository orderRepository) => 
        TypedResults.Ok(await orderRepository.GetAllOrdersAsync());

    private static async Task<Ok<OrderItem>> GetOrder(Guid id, IOrderRepository orderRepository) =>
        TypedResults.Ok(await orderRepository.GetOrderAsync(id));

    private static async Task<Ok> DeleteOrder(Guid id, IOrderRepository orderRepository)
    { 
        await orderRepository.RemoveAsync(id);

        return TypedResults.Ok();
    }

    private static async Task<bool> Cheack(IInventoryGrpcClient inventoryGrpcClient, IPublishEndpoint publishEndpoint)
    {
        return (await inventoryGrpcClient.CheckConnectionAsync(new CheckConnectionRequest())).ErrorCode.HasValue;
    }
}