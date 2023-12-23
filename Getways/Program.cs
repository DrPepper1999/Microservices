const string Order = "order";
const string Product = "product";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(Order, c => c.BaseAddress = new Uri("https://localhost:7156"));

builder.Services
    .AddGraphQLServer()
    .AddRemoteSchema(Order)
    .AddRemoteSchema(Product);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/graphql");
});

app.Run();

