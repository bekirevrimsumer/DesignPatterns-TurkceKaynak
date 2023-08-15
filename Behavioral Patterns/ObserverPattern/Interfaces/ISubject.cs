using ObserverPattern.Models;

namespace ObserverPattern.Interfaces;

public interface ISubject
{
    void Subscribe(IObserver observer, Product product);
    void Unsubscribe(IObserver observer, Product product);
    void Notify(Product product);
}