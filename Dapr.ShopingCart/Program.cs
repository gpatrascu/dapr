using System.Text.Json;
using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var storeName = "statestore";
using var client = new DaprClientBuilder().Build();

var articlesHttpClient = DaprClient.CreateInvokeHttpClient("dapr-articles");

app.MapPost("/shoppingCarts", async (NewShoppingCartRequest newShoppingCartCommand) =>
{
    var shoppingCart = new ShoppingCart(newShoppingCartCommand.UserId);

    await client.SaveStateAsync(storeName, shoppingCart.Id.ToString(), shoppingCart);
    return Results.Ok(ShoppingCartModel.From(shoppingCart));
});

app.MapPost("/shoppingCarts/{shoppingCartId}/items",
    async (Guid shoppingCartId, AddShoppingArticleCommand command) =>
    {
        Console.WriteLine("request made for id {0}", shoppingCartId);
        var article = await articlesHttpClient.GetFromJsonAsync<ArticleDto>($"/articles/{command.ArticleId}");
        if (article == null)
        {
            return Results.NotFound();
        }

        var (shoppingCart, etag) = await client.GetStateAndETagAsync<ShoppingCart>(storeName, shoppingCartId.ToString());

        if (shoppingCart == null)
        {
            return Results.NotFound();
        }
        
        var serialize = JsonSerializer.Serialize(shoppingCart);

        Console.WriteLine(serialize);
        
        shoppingCart.AddArticle(command.ArticleId, command.Quantity, article.Price);

        bool trySaveStateAsync = await client.TrySaveStateAsync(storeName, shoppingCartId.ToString(), shoppingCart, etag);

        Console.WriteLine(trySaveStateAsync);

        return Results.Ok(ShoppingCartModel.From(shoppingCart));
    });

app.MapGet("/shoppingCarts/{shoppingCartId}", async (Guid shoppingCartId) =>
{
    var shoppingCart = await client.GetStateAsync<ShoppingCart>(storeName, shoppingCartId.ToString());

    if (shoppingCart == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(ShoppingCartModel.From(shoppingCart));
});

app.Run();