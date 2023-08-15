using StrategyPattern.Interfaces;

namespace StrategyPattern.Payments;

public class PayPalPayment : IPaymentStrategy
{
    private string _email;
    private string _password;

    public PayPalPayment(string email, string password)
    {
        _email = email;
        _password = password;
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"Processed PayPal payment of {amount} using email {_email}");
    }
}