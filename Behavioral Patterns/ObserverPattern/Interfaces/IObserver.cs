using ObserverPattern.Models;

namespace ObserverPattern.Interfaces;

public interface IObserver
{
    void StockUpdate(Product product);
}