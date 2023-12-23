using MassTransit;
using Microsoft.Extensions.Options;
using Order.API.Apis;
using Order.API.Extensions;
using Order.API.GraphQL;
using Order.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    
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

builder.Services.AddHttpClient("GrpcHttpClient")
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (m, crt, chn, e) => true
        };
    });

builder.Services
    .AddRouting()
    .AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGroup("/api/v1/order")
    .WithTags("Order API")
    .MapOrderApi();

app.Run();
