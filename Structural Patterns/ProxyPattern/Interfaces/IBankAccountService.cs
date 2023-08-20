namespace ProxyPattern.Interfaces;

public interface IBankAccountService
{
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    void GetBalance();
}