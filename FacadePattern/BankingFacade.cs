using FacadePattern.Models;
using FacadePattern.Services;

namespace FacadePattern;

public class BankingFacade
{
    private AccountService accountService;
    private TransactionService transactionService;

    public BankingFacade()
    {
        accountService = new();
        transactionService = new();
    }

    public void CheckAccountBalance(Account account)
    {
        var balance = accountService.GetAccountBalance(account);
        Console.WriteLine($"Hesap bakiyesi: ${balance}");
    }

    public void WithdrawMoney(Account account, decimal amount)
    {
        if (accountService.HasEnoughBalance(account, amount))
        {
            transactionService.Withdraw(account, amount);
        }
        else
        {
            Console.WriteLine("Hesapta yeterli bakiye bulunmamaktadır.");
        }
    }
}