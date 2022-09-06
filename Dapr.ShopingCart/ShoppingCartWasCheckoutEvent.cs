public class ShoppingCartWasCheckoutEvent 
{
    public static ShoppingCartWasCheckoutEvent From(ShoppingCart shoppingCart)
    {
        return new ShoppingCartWasCheckoutEvent()
        {
            Total = shoppingCart.GetTotal(),
            Lines = shoppingCart.Lines.Select(line => new CheckoutLine(line.ArticleId, line.Quantity, line.Price))
                .ToList()
        };
    }

    public IList<CheckoutLine> Lines { get; set; }

    public decimal Total { get; set; }
}