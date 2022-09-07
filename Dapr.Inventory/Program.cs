using Dapr;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseCloudEvents();

// needed for Dapr pub/sub routing
app.MapSubscribeHandler();

app.MapPost("/checkout", [Topic("pubsub", "checkout")] async (ShoppingCartWasCheckoutEvent checkoutEvent) =>
{
    await File.AppendAllLinesAsync(@"inventory.txt",
        checkoutEvent.Lines.Select(line => $"{line.LineArticleId} - {line.LineQuantity}"));
    return Results.Ok();
});

app.Run();