public class ShoppingCartWasCheckoutEvent 
{

    public IList<CheckoutLine> Lines { get; set; }

    public decimal Total { get; set; }
}