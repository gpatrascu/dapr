public class ShoppingCartModel
{
    public static ShoppingCartModel From(ShoppingCart shoppingCart)
    {
        return new ShoppingCartModel()
        {
            Id = shoppingCart.Id,
            Lines = shoppingCart.Lines.Select(line => new ShoppingCartLineModel()
            {
                ArticleId = line.ArticleId,
                Quantity = line.Quantity,
                Price = line.Price
            }).ToList()
        };
    }

    public IList<ShoppingCartLineModel> Lines { get; set; }

    public Guid Id { get; set; }
}

public class ShoppingCartLineModel
{
    public string ArticleId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}