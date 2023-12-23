using Microsoft.EntityFrameworkCore;
using Product.API.Infrastructure;

namespace Product.API.Extensions;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder, ConfigurationManager configuration)
    {
        builder.AddNpgsqlDbContext<ProductContext>("ProductContextConnection", configureDbContextOptions: dbContextOptionsBuilder =>
        {
            dbContextOptionsBuilder.UseNpgsql();
        });

        // REVIEW: This is done for development ease but shouldn't be here in production
        //builder.Services.AddMigration<CatalogContext, CatalogContextSeed>();

        // Add the integration services that consume the DbContext
        // builder.Services.AddTransient<IIntegrationEventLogService, IntegrationEventLogService<CatalogContext>>();
        //
        // builder.Services.AddTransient<ICatalogIntegrationEventService, CatalogIntegrationEventService>();
        //
        // builder.AddRabbitMqEventBus("EventBus")
        //     .AddSubscription<OrderStatusChangedToAwaitingValidationIntegrationEvent, OrderStatusChangedToAwaitingValidationIntegrationEventHandler>()
        //     .AddSubscription<OrderStatusChangedToPaidIntegrationEvent, OrderStatusChangedToPaidIntegrationEventHandler>();

        // builder.Services.AddOptions<CatalogOptions>()
        //     .BindConfiguration(nameof(CatalogOptions));
        //
        // builder.Services.AddOptions<AIOptions>()
        //     .BindConfiguration("AI");
        //
        // builder.Services.AddSingleton<ICatalogAI, CatalogAI>();
    }
}