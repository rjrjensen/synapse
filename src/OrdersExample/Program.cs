using OrdersExample;
using OrdersExample.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.RegisterHttpClients();

builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<AlertService>();
builder.Services.AddScoped<UpdateService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/orders", (OrderService orderService) => orderService.GetOrders())
    .WithName("Get Orders");

app.MapGet("/alert", (AlertService alertService) => alertService.SendAlerts())
    .WithName("Send Alert");

app.MapGet("/update", (UpdateService updateService) => updateService.UpdateOrders())
    .WithName("Update Orders");

app.Run();