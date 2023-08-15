using ObserverPattern.Interfaces;

namespace ObserverPattern.Models;

public class Customer : IObserver
{
    public string Name { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void StockUpdate(Product product)
    {
        Console.WriteLine($"Dear {Name}, {product.Name} is now available at {product.Price}");
    }
}