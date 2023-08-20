using ProxyPattern.Interfaces;

namespace ProxyPattern.ProxyModels;

public class BankAccountProxy : IBankAccountService
{
    private readonly IBankAccountService _bankAccountService;
    
    public BankAccountProxy(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }
    
    public void Deposit(decimal amount)
    {
        _bankAccountService.Deposit(amount);
    }
    
    public void Withdraw(decimal amount)
    {
        _bankAccountService.Withdraw(amount);
    }
    
    public void GetBalance()
    {
        _bankAccountService.GetBalance();
    }
}