using MassTransit;
using Microsoft.Extensions.Options;
using Notification.API.Infrastructure;
using Notification.API.Services;
using Notification.API.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DBSettings>(builder.Configuration.GetSection(DBSettings.SectionName));

builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<DBSettings>>().Value);

builder.Services.Configure<MessageBrokerSettings>(
    builder.Configuration.GetSection(MessageBrokerSettings.SectionName));

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    var assembly = typeof(Program).Assembly;
    
    busConfigurator.AddConsumers(assembly);
    
    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        var settings = context.GetRequiredService<MessageBrokerSettings>();

        configurator.Host(new Uri(settings.Host), h =>
        {
            h.Username(settings.Username);
            h.Password(settings.Password);
        });
        
        configurator.ConfigureEndpoints(context);
    });
});

builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<MessageBrokerSettings>>().Value);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
