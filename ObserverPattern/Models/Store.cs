using ObserverPattern.Interfaces;

namespace ObserverPattern.Models;

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