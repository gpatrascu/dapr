public class CheckoutLine
{
    public string LineArticleId { get; set; }
    public int LineQuantity { get; set; }
    public decimal LinePrice { get; set; }

    public CheckoutLine(string lineArticleId, int lineQuantity, decimal linePrice)
    {
        LineArticleId = lineArticleId;
        LineQuantity = lineQuantity;
        LinePrice = linePrice;
    }
}