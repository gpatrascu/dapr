public class ShoppingCart
{
    public ShoppingCart(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }

    public IList<ShoppingCartLine> Lines { get; } = new List<ShoppingCartLine>();

    public Guid Id { get; } = new();

    public void AddArticle(string articleId, int quantity, decimal articlePrice)
    {
        this.Lines.Add(new ShoppingCartLine(articleId, quantity, articlePrice));
    }
}

public class ShoppingCartLine
{
    public string ArticleId { get; }
    public int Quantity { get; }
    public decimal Price { get; }

    public ShoppingCartLine(string articleId, int quantity, decimal price)
    {
        ArticleId = articleId;
        Quantity = quantity;
        Price = price;
    }
}