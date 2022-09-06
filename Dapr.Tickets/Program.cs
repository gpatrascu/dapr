using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/checkoutEvent", async (ShoppingCartWasCheckoutEvent checkoutEvent) =>
{
    Console.WriteLine(checkoutEvent.Total);
    return Results.Ok();
}).WithTopic("pubsub", "checkout");

app.Run();