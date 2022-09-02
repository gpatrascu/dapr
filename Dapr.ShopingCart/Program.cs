using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var storeName = "ShoppingCart";
using var client = new DaprClientBuilder().Build();

var articlesHttpClient = DaprClient.CreateInvokeHttpClient("articles");

app.MapPost("/shoppingCarts", async (NewShoppingCartRequest newShoppingCartCommand) =>
{
    var shoppingCart = new ShoppingCart(newShoppingCartCommand.UserId);

    await client.SaveStateAsync(storeName, shoppingCart.Id.ToString(), shoppingCart);
    return Results.Ok(ShoppingCartModel.From(shoppingCart));
});

app.MapPost("/shoppingCarts/{shoppingCartId}/items", async (Guid shoppingCartId, AddShoppingArticleCommand command) =>
{
    var article = await articlesHttpClient.GetFromJsonAsync<ArticleDto>($"/articles/{command.ArticleId}");
    if (article == null)
    {
        return Results.NotFound();
    }

    var shoppingCart = await client.GetStateAsync<ShoppingCart>(storeName, shoppingCartId.ToString());

    if (shoppingCart == null)
    {
        return Results.NotFound();
    }
    
    shoppingCart.AddArticle(command.ArticleId, command.Quantity, article.Price);
    return Results.Ok(ShoppingCartModel.From(shoppingCart));
});

app.Run();