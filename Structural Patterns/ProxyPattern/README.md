# Proxy Tasarım Deseni
Proxy Design Pattern, bir nesne üzerinden erişim sağlayarak gerçek nesnenin yaratılmasını veya yönetilmesini kontrol etmeyi amaçlayan bir yapısal tasarım desenidir. Proxy, gerçek nesneyi temsil eder ve istemciye nesnenin yerine geçer. Bu desen, erişim kontrolü, uzak erişim, önbellekleme gibi senaryolarda kullanılabilir. Proxy, istemci ve gerçek nesne arasındaki iletişimi aracılık eder ve istemciye daha fazla esneklik ve güvenlik sağlar.

## Proxy Design Pattern'ın Avantajları
- **Erişim Kontrolü**: Proxy, gerçek nesneye erişimi kontrol ederek istemci ile gerçek nesne arasında ek bir katman oluşturur. Bu sayede, belirli koşullar sağlanmadığında erişimi engelleyebilir veya yönlendirebiliriz.

- **Uzak Erişim**: Eğer gerçek nesne uzak bir sunucuda bulunuyorsa, proxy nesnesi bu nesneye erişimi kolaylaştırabilir. İstemci uzak sunucuya erişmek istediğinde proxy, gerektiğinde verileri iletebilir veya sunucuyla iletişimi sağlayabilir.

- **Performans İyileştirmesi**: Proxy, gerçek nesne yaratılıp yüklenmeden önce bazı işlemleri gerçekleştirebilir. Örneğin, gerektiğinde nesneyi önbellekte tutarak tekrar tekrar yaratma ihtiyacını azaltabilir ve performansı artırabilir.

## Örnek Senaryo: Banka Hesabı İşlemleri
Aşağıda verilen kod örneği, bir banka hesabı işlemleri senaryosunu göstermektedir. IBankAccountService interface'i, hesap işlemleri için metotları tanımlar. BankAccountService sınıfı gerçek hesabı temsil ederken, BankAccountProxy sınıfı bu hesaba erişimi kontrol eder.

- IBankAccountService interface'i, hesap işlemleri için metotları tanımlar.
```C#
public interface IBankAccountService
{
    void WithdrawMoney(decimal amount);
    void DepositMoney(decimal amount);
    void GetBalance();
}
```
- Account sınıfı, hesap bilgilerini tutar.
```C#
public class Account
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
}
```
-  BankAccountService sınıfı, gerçek hesabı temsil eder.
```C#
public class BankAccountService : IBankAccountService
{
    private readonly Account _account;

    public BankAccountService(Account account)
    {
        _account = account;
    }

    public void WithdrawMoney(decimal amount)
    {
        _account.Balance -= amount;
        Console.WriteLine($"{amount} TL withdrawn from the account. Current balance: {_account.Balance} TL");
    }

    public void DepositMoney(decimal amount)
    {
        _account.Balance += amount;
        Console.WriteLine($"{amount} TL deposited to the account. Current balance: {_account.Balance} TL");
    }

    public void GetBalance()
    {
        Console.WriteLine($"Current balance: {_account.Balance} TL");
    }
}
```

- BankAccountProxy sınıfı, hesaba erişimi kontrol eder. Bu sınıf, BankAccountService sınıfını kullanarak hesap işlemlerini gerçekleştirir. İstersek bu sınıfta bazı koşullar sağlanmadığında işlemleri engelleyebilir veya yönlendirebiliriz.
```C#
public class BankAccountProxy : IBankAccountService
{
    private readonly IBankAccountService _bankAccountService;

    public BankAccountProxy(Account account)
    {
        _bankAccountService = new BankAccountService(account);
    }

    public void WithdrawMoney(decimal amount)
    {
        if (amount > 1000)
        {
            Console.WriteLine("You can withdraw up to 1000 TL at a time.");
        }
        else
        {
            _bankAccountService.WithdrawMoney(amount);
        }
    }

    public void DepositMoney(decimal amount)
    {
        if (amount > 5000)
        {
            Console.WriteLine("You can deposit up to 5000 TL at a time.");
        }
        else
        {
            _bankAccountService.DepositMoney(amount);
        }
    }

    public void GetBalance()
    {
        _bankAccountService.GetBalance();
    }
}
```

```C#
Account account = new Account { Id = 1, Balance = 10000 };
IBankAccountService bankAccountService = new BankAccountProxy(account);

bankAccountService.GetBalance();
bankAccountService.DepositMoney(5000);
bankAccountService.WithdrawMoney(2000);
bankAccountService.WithdrawMoney(5000);
bankAccountService.DepositMoney(10000);
bankAccountService.WithdrawMoney(5000);
```