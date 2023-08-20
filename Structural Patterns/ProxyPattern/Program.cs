
using ProxyPattern.Interfaces;
using ProxyPattern.Models;
using ProxyPattern.ProxyModels;
using ProxyPattern.Services;

var account = new Account { Id = 1, Balance = 1000 };
IBankAccountService proxy = new BankAccountProxy(new BankAccountService(account));

proxy.Deposit(100);
proxy.Withdraw(200);
proxy.Withdraw(2000);
proxy.GetBalance();