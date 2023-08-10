
var store = new Store("Amazon");

var product1 = new Product { Name = "iPhone 12", Price = 1000 };
var product2 = new Product { Name = "iPhone 12 Pro", Price = 1200 };

var customer1 = new Customer("John");
var customer2 = new Customer("Mary");
var customer3 = new Customer("Peter");

store.Subscribe(customer1, product1);
store.Subscribe(customer2, product2);
store.Subscribe(customer3, product1);

store.AddProduct(product1);
store.AddProduct(product2);

#region Interfaces
public interface IObserver
{
    void StockUpdate(Product product);
}

public interface ISubject
{
    void Subscribe(IObserver observer, Product product);
    void Unsubscribe(IObserver observer);
    void Notify(Product product);
}
#endregion

#region Classes
public class Store : ISubject
{
    private Dictionary<Product, List<IObserver>> _observers = new();
    public string Name { get; set; }

    public Store(string name)
    {
        Name = name;
    }

    public void Subscribe(IObserver observer, Product product)
    {
        if (!_observers.ContainsKey(product))
        {
            _observers[product] = new List<IObserver>();
        }
        _observers[product].Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        foreach (var productList in _observers.Values)
        {
            productList.Remove(observer);
        }
    }
    
    public void Notify(Product product)
    {
        if (!_observers.ContainsKey(product)) return;
        foreach (var observer in _observers[product])
        {
            observer.StockUpdate(product);
        }
    }

    public void AddProduct(Product product)
    {
        Notify(product);
    }
}

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

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
#endregion