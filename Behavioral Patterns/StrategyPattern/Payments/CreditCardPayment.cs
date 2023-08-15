using StrategyPattern.Interfaces;

namespace StrategyPattern.Payments;

public class CreditCardPayment : IPaymentStrategy
{
    private string _cardNumber;
    private string _expirationDate;
    private string _cvv;

    public CreditCardPayment(string cardNumber, string expirationDate, string cvv)
    {
        _cardNumber = cardNumber;
        _expirationDate = expirationDate;
        _cvv = cvv;
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"Processed credit card payment of {amount} using card number {_cardNumber}");
    }
}