# Singleton Design Pattern

Singleton Design Pattern, bir sınıfın yalnızca bir örneğe sahip olmasını sağlamak için kullanılan bir tasarım desenidir. Bu desen, özellikle bir nesnenin yalnızca bir kere oluşturulmasını ve bu örneğin tüm uygulama boyunca paylaşımlı bir şekilde kullanılmasını sağlamak amacıyla kullanılır.

## Neden Kullanılır?

Bir uygulama içinde tek bir örnek oluşturmanın gerektiği durumlar vardır. Bu örneğin paylaşımlı bir şekilde kullanılması gerekebilir. Singleton Design Pattern, bu tür durumları ele almak ve tekil bir nesnenin örneğini güvence altına almak için kullanılır.

## Avantajlar
Singleton tasarım deseninin avantajları şunlardır:

- **Tekil Örnek**: Desen, bir sınıfın yalnızca bir örneğe sahip olmasını sağlar. Bu, gereksiz nesne oluşturmanın ve kaynak israfının önüne geçer.

- **Paylaşımlı Kullanım**: Tek bir örnek, uygulama boyunca paylaşımlı bir şekilde kullanılabilir. Bu, aynı örneğin farklı yerlerde kullanılması gerektiği senaryolarda işe yarar.

- **Global Erişim**: Singleton nesnesi, her yerden kolayca erişilebilir ve kullanılabilir. Bu, genellikle tek bir yapıyı paylaşan bileşenler arasında iletişimi kolaylaştırır.

## Kod Örneği İncelemesi

Singleton Design Pattern, bir sınıfın yalnızca bir örneğe sahip olmasını sağlamak için kullanılan bir tasarım desenidir. Bu desen, özellikle bir nesnenin yalnızca bir kere oluşturulmasını ve bu örneğin tüm uygulama boyunca paylaşımlı bir şekilde kullanılmasını sağlamak amacıyla kullanılır.

```csharp
public class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();

    private Singleton()
    {
    }

    public static Singleton GetInstance()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
        }

        return _instance;
    }
}
```

Singleton sınıfı private bir constructor ile dışarıdan erişime kapalıdır. Bu sayede sınıfın yalnızca bir örneğe sahip olması sağlanır. Ayrıca sınıfın tek bir örneğe sahip olması için _instance adında private bir static değişken tanımlanır. Bu değişkenin değeri null olarak atanır. `GetInstance()` metodu ile sınıfın tek bir örneğe sahip olması sağlanır. Bu metot içerisinde _instance değişkeninin null olup olmadığı kontrol edilir. Eğer değişkenin değeri null ise yeni bir Singleton örneği oluşturulur ve _instance değişkenine atanır. Eğer değişkenin değeri null değil ise zaten bir örnek oluşturulmuş demektir. Bu durumda _instance değişkeninin değeri döndürülür.

Ayrıca bir kilit(lock) mekanizması kullanılarak çoklu threadlerin aynı anda GetInstance() metodunu çağırması engellenir. Bu sayede çoklu threadlerin aynı anda GetInstance() metodunu çağırması durumunda sınıfın yalnızca bir örneğe sahip olması sağlanır.