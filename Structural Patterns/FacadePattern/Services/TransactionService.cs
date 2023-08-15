using FacadePattern.Models;

namespace FacadePattern.Services;

public class TransactionService
{
    public void Withdraw(Account account, decimal amount)
    {
        account.Balance -= amount;
        Console.WriteLine($"{account.Id}'li hesaptan ${amount} tutarında para çekildi.");
    }
}