using Inventory.API.Apis;
using Inventory.API.Extensions;
using Inventory.API.Grpc;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();

builder.Services.AddCodeFirstGrpc();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("/api/v1/inventory")
    .WithTags("Inventory API")
    .MapInventoryApi();

app.MapGrpcService<InventoryGrpcService>();

app.Run();