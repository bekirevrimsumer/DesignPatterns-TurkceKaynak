using FacadePattern.Models;

namespace FacadePattern.Services;

public class AccountService
{
    public decimal GetAccountBalance(Account account)
    {
        return account.Balance;
    }
    
    public bool HasEnoughBalance(Account account, decimal amount)
    {
        return GetAccountBalance(account) >= amount;
    }
}