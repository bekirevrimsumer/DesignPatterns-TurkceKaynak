## Command Design Pattern
Command tasarım deseni, davranışsal bir tasarım deseni olarak bilinir ve bir işlemi nesne olarak kapsüller. Bu desen, isteği farklı nesneler arasında iletmek, kaydetmek veya geri almak için kullanılır. Command deseni, bağlamın ve komutların birbirinden bağımsız olarak değişmesine olanak tanır.

### Temel Kavramlar
- Komut (Command): Bir işlemi gerçekleştirmek için gereken tüm bilgileri ve yöntemi içeren bir arayüzdür. Bu arayüz, Execute adında bir yöntem içerir.

- Alıcı (Receiver): Bir işlemi gerçekleştiren gerçek nesnedir. Komut, alıcıya yönlendirilir ve ardından alıcı işlemi gerçekleştirir.

- Çalıştırıcı (Invoker): Komutları işleyen ve yönlendiren nesnedir. Çalıştırıcı, komutun nasıl yürütüleceğini bilmek zorunda değildir.

- İstemci (Client): Komutları oluşturan ve çalıştırıcıya gönderen nesnedir.


### Örnek Senaryo: Restoran Sipariş Yönetimi
Bir restoran senaryosunda Command deseni kullanımını düşünelim:

#### Temel Sınıflar
- Chef: Yemekleri hazırlayan alıcıyı temsil eder. PrepareBeef ve PrepareSoup gibi işlemleri gerçekleştirebilir.
```csharp
public class Chef
{
    public void PrepareBeef()
    {
        Console.WriteLine("Preparing beef...");
    }

    public void PrepareSoup()
    {
        Console.WriteLine("Preparing soup...");
    }
}
```
- BeefOrderCommand ve SoupOrderCommand: Bu sınıflar, sırasıyla et ve çorba siparişlerini temsil eden komut nesnelerini oluşturur. Her komut nesnesi, ilgili yemeği hazırlama işlemini içerir.
```csharp
public class BeefOrderCommand : ICommand
{
    private readonly Chef _chef;

    public BeefOrderCommand(Chef chef)
    {
        _chef = chef;
    }

    public void Execute()
    {
        _chef.PrepareBeef();
    }
}

public class SoupOrderCommand : ICommand
{
    private readonly Chef _chef;

    public SoupOrderCommand(Chef chef)
    {
        _chef = chef;
    }

    public void Execute()
    {
        _chef.PrepareSoup();
    }
}
```
- Waiter: Siparişleri alır ve işler. TakeOrder metodu ile siparişleri alır, PlaceOrders metodu ile siparişleri şeflere ileterek hazırlanmalarını sağlar.
```csharp
public class Waiter
{
    private readonly List<ICommand> _orders = new List<ICommand>();

    public void TakeOrder(ICommand order)
    {
        _orders.Add(order);
    }

    public void PlaceOrders()
    {
        foreach (var order in _orders)
        {
            order.Execute();
        }
    }
}
```
### Uygulama Aşamaları
- Müşteri bir sipariş verir. Bu sipariş, BeefOrderCommand veya SoupOrderCommand gibi komut nesneleri olarak temsil edilir.
- Waiter, aldığı sipariş komutunu alır ve PlaceOrders metoduyla şeflere ileterek siparişlerin hazırlanmasını sağlar.
- Şefler, ilgili komut nesnesini alır ve komutun içindeki Execute yöntemini çağırarak yemeği hazırlar.
- Bu sayede işlemler komut nesneleri aracılığıyla sırasıyla gerçekleştirilir.

### Sonuç
Command tasarım deseni, işlemleri nesnelere dönüştürerek esneklik, geri alma ve işlem geçmişi takibi gibi avantajlar sunar. Bu örnekte, restoran sipariş yönetimi senaryosu üzerinden Command deseninin nasıl kullanılabileceğini gördük. Pattern'ın detaylı kullanımı hakkında ayrıntılı bilgiler için [bu rehberi](https://refactoring.guru/design-patterns/command) inceleyebilirsiniz.