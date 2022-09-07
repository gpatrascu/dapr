using Dapr;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseCloudEvents();

// needed for Dapr pub/sub routing
app.MapSubscribeHandler();

app.MapPost("/checkout", 
    [Topic("pubsub", "checkout")] 
    async (ShoppingCartWasCheckoutEvent checkoutEvent) =>
{
    Console.WriteLine("we receive an event");
    await File.AppendAllLinesAsync("money.txt", new [] { $"{checkoutEvent.Total}" });
        
    return Results.Ok();
});

app.Run();