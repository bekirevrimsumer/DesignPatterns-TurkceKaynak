using ProxyPattern.Interfaces;
using ProxyPattern.Models;

namespace ProxyPattern.Services;

public class BankAccountService : IBankAccountService
{
    public Account Account { get; set; }
    
    public BankAccountService(Account account)
    {
        Account = account;
    }
    
    public void Deposit(decimal amount)
    { 
        Account.Balance += amount;
        Console.WriteLine($"Deposited {amount}, new balance is {Account.Balance}");
    }

    public void Withdraw(decimal amount)
    {
        if (Account.Balance >= amount)
        {
            Account.Balance -= amount;
            Console.WriteLine($"Withdrew {amount}, new balance is {Account.Balance}");
        }
        else
        {
            Console.WriteLine($"Could not withdraw {amount}, insufficient funds");
        }
    }

    public void GetBalance()
    {
        Console.WriteLine($"Balance is {Account.Balance}");
    }
}