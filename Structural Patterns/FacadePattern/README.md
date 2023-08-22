# Facade Design Pattern

Facade Design Pattern, karmaşık alt sistemler veya nesne gruplarını daha basit bir arabirimle kullanmanızı sağlayan bir yapısal tasarım desenidir. Bu desen, bir yazılım sisteminin karmaşıklığını gizlemek ve istemcilerin bu karmaşıklıkla uğraşmadan sistemi kullanmalarını sağlamak amacıyla kullanılır. Facade deseni, alt sistemdeki nesneler ve işlemler hakkında ayrıntılı bilgiye sahip olmayı gerektirmez; bu nedenle daha düşük bağımlılık ve daha iyi sürdürülebilirlik sağlar.

Facade deseninin kullanım senaryoları şu şekilde özetleyebiliriz:

- **Karmaşık Alt Sistemlerin Basitleştirilmesi**: Bir yazılım sistemi, alt sistemler veya bileşenler ağıyla karmaşıksa, bu alt sistemlerin işlevselliğini bir facade sınıfı içine saklamak, sistem kullanıcılarının sadece bu sınıfı kullanarak işlem yapmalarını sağlar.

- **Daha İyi Bir Arabirim Sağlama**: Kullanıcıların alt sistemlerle doğrudan etkileşime girmesi yerine, daha basit ve tutarlı bir arabirim sağlayarak işlemleri kolaylaştırabilirsiniz.

- **Sistemin Genelinde Düzgün Bir Erişim Sağlama**: Farklı modüller veya bileşenler arasındaki iletişimi düzenlemek ve merkezi bir erişim noktası oluşturmak için facade kullanılabilir.

## Örnek Uygulama

### Senaryo Açıklaması:

Elimizde, bankacılık işlemlerini yapan bir uygulamanın Facade deseni kullanılarak tasarlanmış bir örneği var. Bu örnekteki kod, bir banka hesabının bakiye kontrolünü ve para çekme işlemini basit bir arabirimle gerçekleştirmek için Facade desenini kullanır.

Öncelikle bu örneği Facade Design Pattern kullanmadan tasarlayalım.

```csharp
public class Account
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
}

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

public class TransactionService
{
    public void Withdraw(Account account, decimal amount)
    {
        account.Balance -= amount;
        Console.WriteLine($"{account.Id}'li hesaptan ${amount} tutarında para çekildi.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Account account = new Account
        {
            Id = 1,
            Balance = 1500.00M
        };

        AccountService accountService = new AccountService();
        TransactionService transactionService = new TransactionService();

        // Hesap bakiyesini kontrol etme
        decimal balance = accountService.GetAccountBalance(account);
        Console.WriteLine($"Hesap bakiyesi: ${balance}");

        // Para çekme işlemi
        decimal amountToWithdraw = 500.00M;
        if (accountService.HasEnoughBalance(account, amountToWithdraw))
        {
            transactionService.Withdraw(account, amountToWithdraw);
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye");
        }

        // Hesap bakiyesini tekrar kontrol etme
        balance = accountService.GetAccountBalance(account);
        Console.WriteLine($"Güncel hesap bakiyesi: ${balance}");

        Console.ReadLine();
    }
}
```
Bu örnekte, Facade tasarım deseni kullanılmadan alt sistemler ve işlemler doğrudan kullanılmıştır. Bu durum, karmaşıklığı artırabilir ve kodun anlaşılabilirliğini ve sürdürülebilirliğini azaltabilir. Facade deseni olmadan, kod parçacıkları doğrudan kontrol edilerek ve yönetilerek daha karmaşık bir yapı oluşabilir. Bu nedenle, Facade deseni gibi yapısal tasarım desenleri, karmaşıklığı gizlemek ve daha temiz bir kod yapısı oluşturmak için önemlidir.

Şimdi, Facade deseni kullanarak bu örneği yeniden tasarlayalım.

- Account sınıfı, hesap bilgilerini temsil eder.
```csharp
public class Account
{
    public int AccountNumber { get; set; }
    public decimal Balance { get; set; }
}
```

- AccountService sınıfı, hesapla ilgili işlemleri gerçekleştirir.

```csharp
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
```
  
- TransactionService sınıfı, para çekme işlemini gerçekleştirir.

```csharp
public class TransactionService
{
    public void Withdraw(Account account, decimal amount)
    {
        account.Balance -= amount;
    }
}
```

- BankingFacade sınıfı, bu alt sistemleri bir araya getirir ve kullanımı kolay bir arabirim sunar.

```csharp
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
```

Program.cs içerisinde BankingFacade sınıfı kullanılarak işlemler gerçekleştirilir.

```csharp
class Program
{
    static void Main(string[] args)
    {
        Account account = new Account
        {
            AccountNumber = 1,
            Balance = 1500.00M
        };

        BankingFacade bankingFacade = new BankingFacade();

        // Hesap bakiyesini kontrol etme
        bankingFacade.CheckAccountBalance(account);

        // Para çekme işlemi
        decimal amountToWithdraw = 500.00M;
        bankingFacade.WithdrawMoney(account, amountToWithdraw);

        // Hesap bakiyesini tekrar kontrol etme
        bankingFacade.CheckAccountBalance(account);

        Console.ReadLine();
    }
}
```

Bu tasarım, kullanıcıların hesap bakiyesini kontrol etmelerini ve para çekmelerini sağlar. Kullanıcılar, doğrudan alt sistemlerle uğraşmadan, sadece BankingFacade sınıfını kullanarak bu işlemleri gerçekleştirebilirler. Bu sayede karmaşıklık gizlenir ve daha temiz bir kod yapısı oluşturulur.