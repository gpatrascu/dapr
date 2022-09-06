public class ShoppingCart
{
    public ShoppingCart(string userId)
    {
        UserId = userId;
        this.Id = Guid.NewGuid();
        this.Lines = new List<ShoppingCartLine>();
        this.Status = "opened";
    }

    public string UserId { get; }

    public IList<ShoppingCartLine> Lines { get; set; } 

    public Guid Id { get; set; } 

    public void AddArticle(string articleId, int quantity, decimal articlePrice)
    {
        this.Lines.Add(new ShoppingCartLine(articleId, quantity, articlePrice));
    }

    public void Checkout()
    {
        this.Status = "checkout";
    }

    public string Status { get; set; }

    public decimal GetTotal()
    {
        return this.Lines.Sum(line => line.TotalLine);
    }
}

public class ShoppingCartLine
{
    public string ArticleId { get; }
    public int Quantity { get; }
    public decimal Price { get; }
    public decimal TotalLine => Price * Quantity;

    public ShoppingCartLine(string articleId, int quantity, decimal price)
    {
        ArticleId = articleId;
        Quantity = quantity;
        Price = price;
    }
}