# Gözlemci Tasarım Deseni (Observer Pattern)

## Sorun

Müşterilerimizin ve bir de mağazanın olduğunu hayal edelim. Müşteri, belirli bir ürüne (mesela yeni bir iPhone modeline) ilgi duyuyor ve bu ürünün yakın bir zamanda mağazada bulunacağını biliyor.

Müşteri, her gün mağazayı ziyaret edebilir ve ürünün stok durumunu kontrol edebilir. Ancak ürün henüz stoklarda bulunmuyorken gerçekleştirdiği tüm ziyaretleri zaman kaybı olacaktır.

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

Bu örnek, Observer Design Pattern'in nasıl çalıştığını ve nasıl kullanıldığını göstermektedir. Bu örnek, bir mağazanın ürün stoklarının güncellenmesini izleyen müşteri nesnelerini temsil eden bir senaryoyu ele almaktadır.

## Senaryo

Müşteriler, belirli ürünlerin stokları güncellendiğinde bilgilendirilmek istiyorlar. Ancak mağaza, tüm müşterilere gereksiz yere bildirim göndermek istemiyor. Bu durumda Observer Design Pattern devreye girer. İlgili nesne (mağaza) müşteri nesnelerini izler ve ürün stoku güncellendiğinde ilgili müşterilere bildirim gönderir.

## Kod Örneği

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
## Arabirimler ve Sınıflar
### IObserver Interface'i
Customer nesnelerinin uygulaması gereken interface'dir. Bu interface, müşterilere ürün stok güncellemelerini ileten StockUpdate metodu içerir.

### ISubject Interface'i
Store class'ının uygulaması gereken interface'dir. Bu interface, müşterileri abone yapmak, abonelikten çıkarmak ve güncellemeleri bildirmek için metotları içerir.

### Store Sınıfı
Mağazayı temsil eden sınıftır. Müşterileri ve ürünleri izler, abone yapar ve güncellemeleri bildirir.

### Customer Sınıfı
Müşteriyi temsil eden sınıftır. Ürün stoku güncellendiğinde StockUpdate metodu çağrılır ve müşteriye bildirim yapılır.

### Product Sınıfı
Ürünü temsil eden sınıftır. İsim ve fiyat gibi özelliklere sahiptir.

### Metotlar
- Subscribe(IObserver observer, Product product): Bir müşteriyi belirli bir ürüne abone yapar.
- Unsubscribe(IObserver observer): Bir müşteriyi abonelikten çıkarır.
- Notify(Product product): Ürün stoku güncellendiğinde abonelere bildirim yapar.
- AddProduct(Product product): Ürünü mağazaya ekler ve güncellemeleri bildirir.

Pattern'ın detaylı kullanımı hakkında ayrıntılı bilgiler için [bu rehberi](https://refactoring.guru/design-patterns/observer) inceleyebilirsiniz.


