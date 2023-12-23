using Inventory.API.Services;
using Inventory.API.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Order.API.Infrastructure;
using Order.API.Services;

namespace Order.API.Extensions;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<OrderDBSettings>(builder.Configuration.GetSection(OrderDBSettings.SectionName));
        
        builder.Services.AddSingleton(sp =>
            sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

        
        builder.Services.Configure<MessageBrokerSettings>(
            builder.Configuration.GetSection(MessageBrokerSettings.SectionName));
        
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();

        builder.Services.AddScoped<IInventoryGrpcClient, InventoryGrpcClient>();

        builder.Services.AddScoped<OrderService>();
    }
}