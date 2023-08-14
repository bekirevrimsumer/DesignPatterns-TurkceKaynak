using FacadePattern;
using FacadePattern.Models;

BankingFacade bankingFacade = new();

var account = new Account
{
    Id = 1,
    Balance = 1500.00M
};

bankingFacade.CheckAccountBalance(account);
bankingFacade.WithdrawMoney(account, 500.00M);
bankingFacade.CheckAccountBalance(account);
bankingFacade.WithdrawMoney(account, 1200.00M);
bankingFacade.CheckAccountBalance(account);

