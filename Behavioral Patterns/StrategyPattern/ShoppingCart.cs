using StrategyPattern.Interfaces;
using StrategyPattern.Models;

namespace StrategyPattern;

public class ShoppingCart
{
    private List<Product> _products = new List<Product>();
    private IPaymentStrategy _paymentStrategy;

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void Checkout()
    {
        var totalAmount = _products.Sum(p => p.Price);
        Console.WriteLine($"Total amount: {totalAmount}");
        
        if (_paymentStrategy != null)
        {
            _paymentStrategy.Pay(totalAmount);
        }
        else
        {
            Console.WriteLine("Please set a payment method before checking out.");
        }
    }
}