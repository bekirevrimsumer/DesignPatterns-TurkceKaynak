# Gözlemci Tasarım Deseni (Observer Pattern)

## Sorun

Müşterilerimizin ve bir de mağazamızın olduğunu hayal edelim. Müşteri, belirli bir ürüne (mesela yeni bir iPhone modeline) ilgi duyuyor ve bu ürünün yakın bir zamanda mağaza stoklarına ekleneceğini biliyor varsayalım.

Müşteri, her gün mağazayı ziyaret edebilir ve ürünün stok durumunu kontrol edebilir. Ancak ürün henüz stoklarda olmadığı durumlarda gerçekleştirdiği tüm ziyaretleri zaman kaybı olacaktır.

Diğer yandan mağaza, yeni bir ürün stoklarda mevcut hale geldiğinde tüm müşterilerine e-posta gönderebilir. Bu, bazı müşterileri sürekli mağazayı ziyaret etmekten kurtarırken, yeni ürünlere ilgi duymayan diğer müşterileri rahatsız edebilir.

Bu durumda bir çatışma var gibi görünüyor. Ya müşteri, ürün stoklarını kontrol etmek için zamanını harcıyor ya da mağaza, tüm müşterilerine bildirim göndermek için kaynak harcıyor.

## Çözüm

Observer Design Pattern, bu çatışmayı çözmek için bir çözüm sunar. Bu tasarım deseni, bir nesnenin durumunda meydana gelen değişiklikleri diğer nesnelere bildirmek için bir mekanizma sağlar.

Observer tasarım deseni, yayıncı(subject) sınıfına bir abonelik mekanizması eklemenizi önerir, böylece abone(observer) nesneler bu yayıncının gelen olay akışına abone olabilir veya abonelikten çıkabilir. Bu mekanizma 
1) abonelerin referanslarını saklamak için bir dizi alan ve
2) aboneleri bu listeye eklemek ve listeden çıkarmak için kullanılacak birkaç genel yöntemden oluşur.

### Abonelik Mekanizması
Abonelik mekanizması, Observer nesnelerin Subject nesnenin bildirimlerine abone olmalarını sağlar.

Artık Subject'ta önemli bir olay meydana geldiğinde, abonelerin üzerinden geçer ve onların nesnelerinde bir bildirim metodu çağırır.

Not: Tüm Observer'ların aynı interface'i implement etmesi ve Subject'in onlarla yalnızca bu interface aracılığıyla iletişim kurması çok önemlidir.

# Gözlemci Tasarım Deseni (Observer Pattern) Örneği

## Senaryo

Müşteriler, belirli ürünlerin stokları güncellendiğinde bilgilendirilmek istiyorlar. Ancak mağaza, tüm müşterilere gereksiz yere bildirim göndermek istemiyor. Bu durumda Observer Design Pattern devreye girer. İlgili nesne (mağaza) müşteri nesnelerini izler ve ürün stoku güncellendiğinde ilgili müşterilere bildirim gönderir.

## Kötü Tasarım

Öncelikle bu senaryoyu kötü bir tasarım ile ele alalım. Bir ürün stoklara eklendiğinde, mağaza tüm müşterilere bildirim gönderir. Bu, mağazanın gereksiz yere kaynak harcamasına neden olur.

```csharp
public class Customer
{
    public string Name { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void ReceiveStockUpdate(Product product)
    {
        Console.WriteLine($"Dear {Name}, {product.Name} is now available at {product.Price}");
    }
}
```

`Store` sınıfı, müşterileri izler ve ürün stokları güncellendiğinde müşterilere bildirim gönderir. `NotifyCustomers()` metodu, tüm müşterileri dolaşır ve her biri için `ReceiveStockUpdate()` yöntemini çağırır. Ancak bu, mağazanın gereksiz yere kaynak harcamasına neden olur. Çünkü bazı müşteriler yeni ürünlerden ilgi duymayabilir. Bu durumda mağaza, bu müşterilere gereksiz yere bildirim gönderir. Yeni ürünlere ilgi duymayan müşteriler, bu bildirimlerden rahatsız olabilir.

```csharp
public class Store
{
    private List<Customer> _customers = new();
    public string Name { get; set; }

    public Store(string name)
    {
        Name = name;
    }

    public void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
    }

    public void RemoveCustomer(Customer customer)
    {
        _customers.Remove(customer);
    }

    public void NotifyCustomers(Product product)
    {
        foreach (var customer in _customers)
        {
            customer.ReceiveStockUpdate(product);
        }
    }

    public void AddProduct(Product product)
    {
        NotifyCustomers(product);
    }
}
```

```csharp
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

```csharp
var store = new Store("Amazon");

var product1 = new Product { Name = "iPhone 12", Price = 1000 };
var product2 = new Product { Name = "iPhone 12 Pro", Price = 1200 };

var customer1 = new Customer("John");
var customer2 = new Customer("Mary");
var customer3 = new Customer("Peter");

store.AddCustomer(customer1);
store.AddCustomer(customer2);
store.AddCustomer(customer3);

store.AddProduct(product1);
store.AddProduct(product2);
```

## İyi Tasarım
## Arabirimler ve Sınıflar
### IObserver Interface'i
Customer nesnelerinin uygulaması gereken interface'dir. Bu interface, müşterilere ürün stok güncellemelerini ileten StockUpdate metodu içerir.

```csharp
public interface IObserver
{
    void StockUpdate(Product product);
}
```

### ISubject Interface'i
Store class'ının uygulaması gereken interface'dir. Bu interface, müşterileri abone yapmak, abonelikten çıkarmak ve güncellemeleri bildirmek için metotları içerir.

```csharp
public interface ISubject
{
    void Subscribe(IObserver observer, Product product);
    void Unsubscribe(IObserver observer);
    void Notify(Product product);
}
```

### Product Sınıfı
Ürünü temsil eden sınıftır. İsim ve fiyat gibi özelliklere sahiptir.

```csharp
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### Store Sınıfı
`Store` sınıfı, `ISubject` interface'ini uygular. Bu sınıf, müşterileri izler ve ürün stokları güncellendiğinde müşterilere bildirim gönderir. Notify() metodu, müşterileri dolaşır ve her biri için StockUpdate() yöntemini çağırır. Bir dictionary kullanarak, her bir ürün için abone olan müşterileri tutuyoruz. Bu dictionary, Product nesnesi ile IObserver nesneleri arasında bir ilişki kurar. Bir ürün stoklara eklendiğinde, sadece bu ürün için abone olan müşterilere bildirim gönderilir. Bu, mağazanın gereksiz yere kaynak harcamasını önler.

```csharp
public class Store : ISubject
{
    private Dictionary<Product, List<IObserver>> _observers = new();
    public string Name { get; set; }

    public Store(string name)
    {
        Name = name;
    }

    public void Subscribe(IObserver observer, Product product)
    {
        if (!_observers.ContainsKey(product))
        {
            _observers[product] = new List<IObserver>();
        }
        _observers[product].Add(observer);
    }

    public void Unsubscribe(IObserver observer, Product product)
    {
        if (!_observers.ContainsKey(product)) return;
        _observers[product].Remove(observer);
    }
    
    public void Notify(Product product)
    {
        if (!_observers.ContainsKey(product)) return;
        foreach (var observer in _observers[product])
        {
            observer.StockUpdate(product);
        }
    }

    public void AddProduct(Product product)
    {
        Notify(product);
    }
}
```

### Customer Sınıfı
Müşteriyi temsil eden sınıftır. Ürün stoku güncellendiğinde StockUpdate metodu çağrılır ve müşteriye bildirim yapılır.

```csharp
public class Customer : IObserver
{
    public string Name { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void StockUpdate(Product product)
    {
        Console.WriteLine($"Dear {Name}, {product.Name} is now available at {product.Price}");
    }
}
```

### Kullanım

```csharp
// Mağaza ve ürünleri oluşturma
var store = new Store("Amazon");
var product1 = new Product { Name = "iPhone 12", Price = 1000 };
var product2 = new Product { Name = "iPhone 12 Pro", Price = 1200 };

// Müşterileri oluşturma
var customer1 = new Customer("John");
var customer2 = new Customer("Mary");
var customer3 = new Customer("Peter");

// Müşterileri ürünlere abone yapma
store.Subscribe(customer1, product1);
store.Subscribe(customer2, product2);
store.Subscribe(customer3, product1);

// Ürünleri mağazaya ekleme
store.AddProduct(product1);
store.AddProduct(product2);
```

Mağaza her yeni ürün eklediğinde o ürün için abone olan müşterilere bildirim gönderilir. Bu, mağazanın gereksiz yere kaynak harcamasını önler. Yeni ürünlere ilgi duymayan müşteriler, mağazanın yeni ürünler eklediğinde bildirim almayacaktır. Böylece yazımızın başında bahsettiğimiz iki sorunun da önüne geçmiş oluyoruz.
