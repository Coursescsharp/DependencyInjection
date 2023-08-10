namespace Module2.BeforeDI.Models.Model;

public class Product
{
    public Product(Guid id, string name, Money price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Money Price { get; set; }
    public int Stock { get; set; }

    public override string? ToString()
    {
        return $"Product {nameof(Name)}: {Name}, {nameof(Price)}: {Price}, {nameof(Stock)}: {Stock}";
    }
}
