var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var articles = new Dictionary<int, Article>
{
    { 1, new Article(1, "Banana", 12.1m) },
    { 2, new Article(2, "apple", 2.1m) },
    { 3, new Article(3, "bread", 5m) }
};

app.MapGet("/articles/{id}", (int id) =>
    !articles.ContainsKey(id) ? Results.NotFound() : Results.Ok(articles[id]));

app.Run();