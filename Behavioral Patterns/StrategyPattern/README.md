# Strategy Design Pattern

Strategy Design Pattern, birbiriyle değiştirilebilir algoritmaların yönetimini sağlamak için kullanılan bir yapısal tasarım desenidir. Bu desen, bir işlemi farklı yöntemlerle gerçekleştirmek veya çalışma zamanında algoritma seçimini yapmak istediğimizde kullanılır. Bu sayede algoritmaları bağımsız olarak değiştirilebilir hale getirir.

## Neden Strategy Design Pattern Kullanılır?

- **Algoritmaların Değiştirilebilirliği**: Farklı durumlar veya gereksinimler için farklı algoritmalar kullanmak istediğimizde, her bir algoritmayı bağımsız olarak yönetebilmek önemlidir.

- **Tek Sorumluluk İlkesi (Single Responsibility Principle)**: Strategy deseni, her algoritmanın tek bir sorumluluğu olduğu ve değiştirilebilir olduğu bir yapı sağlar.

- **Kod Tekrarının Azaltılması**: Farklı yerlerde aynı veya benzer algoritmayı tekrar tekrar yazmak yerine, Strategy Design Pattern ile algoritmaları yeniden kullanabiliriz.

## Ödeme Yöntemleri Örneği: Strategy Design Pattern

Örneğin, bir ödeme sistemi tasarımını düşünelim. Bu sistemde farklı ödeme yöntemleri (kredi kartı, PayPal, banka transferi) bulunabilir ve her biri farklı algoritmaları temsil eder. Strategy tasarım deseni ile her ödeme yöntemi bir strateji olarak temsil edilir ve ödeme işlemi için uygun strateji seçilir. Böylece ödeme yöntemlerinin yönetimi ve değiştirilmesi kolaylaşır.

### Strategy Design Pattern Uygulamadan Önce (Kötü Tasarım)

Ödeme yöntemlerini temsil eden sınıfların hepsi aynı arayüze sahip değildir. Bu yüzden ödeme işlemi gerçekleştirilirken, ödeme yöntemine göre farklı algoritma kullanmak için `if-else` veya `switch-case` gibi kontrol yapıları kullanmak gerekebilir. Bu durumda, her yeni ödeme yöntemi için kontrol yapılarına yeni bir şart eklemek gerekecektir. Bu da kod tekrarına ve karmaşıklığa yol açar.

```csharp
public class Payment
{
    public void Pay(string paymentMethod)
    {
        if (paymentMethod == "CreditCard")
        {
            // CreditCardPayment algoritması
        }
        else if (paymentMethod == "PayPal")
        {
            // PayPalPayment algoritması
        }
        else if (paymentMethod == "BankTransfer")
        {
            // BankTransferPayment algoritması
        }
    }
}
```

### Strategy Design Pattern Uyguladıktan Sonra (İyi Tasarım)

Strategy tasarım deseni ile her ödeme yöntemi bir strateji olarak temsil edilir ve ödeme işlemi için uygun strateji seçilir. Böylece ödeme yöntemlerinin yönetimi ve değiştirilmesi kolaylaşır.

```csharp
public interface IPaymentStrategy
{
    void Pay(double amount);
}
```

```csharp
public class CreditCardPayment : IPaymentStrategy
{
    private string _cardNumber;
    private string _expirationDate;
    private string _cvv;

    public CreditCardPayment(string cardNumber, string expirationDate, string cvv)
    {
        _cardNumber = cardNumber;
        _expirationDate = expirationDate;
        _cvv = cvv;
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"Processed credit card payment of {amount} using card number {_cardNumber}");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    private string _email;
    private string _password;

    public PayPalPayment(string email, string password)
    {
        _email = email;
        _password = password;
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"Processed PayPal payment of {amount} using email {_email}");
    }
}
```

```csharp
public class ShoppingCart
{
    private List<Product> _products = new List<Product>();
    private IPaymentStrategy _paymentStrategy;

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy;
    }

    public void Checkout()
    {
        var totalAmount = _products.Sum(p => p.Price);
        Console.WriteLine($"Total amount: {totalAmount}");
        
        if (_paymentStrategy != null)
        {
            _paymentStrategy.Pay(totalAmount);
        }
        else
        {
            Console.WriteLine("Please set a payment method before checking out.");
        }
    }
}
```

```csharp

var shoppingCart = new ShoppingCart();
shoppingCart.AddProduct(new Product("Product 1", 100));
shoppingCart.AddProduct(new Product("Product 2", 200));

shoppingCart.SetPaymentStrategy(new CreditCardPayment("123456789", "12/2022", "123"));
shoppingCart.Checkout();

shoppingCart.SetPaymentStrategy(new PayPalPayment("test@test.com", "123456"));
shoppingCart.Checkout();

// Output:
// Total amount: 300
// Processed credit card payment of 300 using card number 123456789
// Total amount: 300
// Processed PayPal payment of 300 using email test@test
```

Bu örnekte, Strategy tasarım deseni ödeme yöntemlerinin değiştirilebilirliğini ve farklı algoritmaların yönetimini sağlar. Ödeme yöntemlerini temsil eden stratejiler (örneğin CreditCardPayment ve PayPalPayment) ConcreteStrategy sınıflarıdır. Ödeme işlemi gerçekleştirileceği zaman, uygun strateji seçilip kullanılır.