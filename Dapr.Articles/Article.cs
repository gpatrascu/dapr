public class Article
{
    public Article(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
}