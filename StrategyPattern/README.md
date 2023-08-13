## Strategy Design Pattern

### Sorunun Tanımı:

Uygulamalar bazı durumlarda farklı veritabanı sistemleriyle çalışmak zorunda kalabilirler. Örneğin, MySQL veya
PostgreSQL gibi farklı veritabanlarına bağlanmanın farklı yöntemleri ve sorgu biçimleri olabilir. Bu durumda, kodun
farklı veritabanı sistemleri arasında geçiş yapması ve uyumlu kalması gerekmektedir. Ancak bu tür farklılıkların
yönetimi ve değişikliklerin entegrasyonu zaman alıcı ve hatalara açık bir süreç olabilir.

### Strategy Tasarım Deseni ile Çözüm:

Bu sorunu çözmek için Strategy tasarım deseni, farklı veritabanı erişim stratejilerini soyutlamayı ve değiştirilebilir
hale getirmeyi sağlar. Her bir veritabanı erişimi farklı bir strateji olarak ele alınır ve bu stratejilerin tümü, aynı
arayüzü (IDatabaseStrategy) uygular. Bu sayede, istemci kod, herhangi bir veritabanı stratejisini kullanabilir hale
gelirken, yeni veritabanı türleri eklendikçe esnek bir şekilde uyarlanabilir.

### Örnek Senaryo Açıklaması:

Bu örnekte, bir e-ticaret uygulaması düşünelim. Bu uygulama farklı veritabanı sistemleri ile çalışabilmesi gerekiyor.
MySQL ve PostgreSQL veritabanlarına erişim stratejileri olarak iki ayrı strateji oluşturuldu. Bu stratejiler,
IDatabaseStrategy arayüzünü uyguluyor ve Connect ve Query gibi metodları içeriyor.

```csharp
    public interface IDatabaseStrategy
    {
        void Connect();
        void Query(string query);
    }
```

```csharp

    public class SqlServerStrategy : IDatabaseStrategy
    {
        public void Connect()
        {
            Console.WriteLine("Connected to SQL Server");
        }
        
        public void Query(string query)
        {
            Console.WriteLine($"Query: {query}");
        }
    }
```

```csharp
public class OracleStrategy : IDatabaseStrategy
{
    public void Connect()
    {
        Console.WriteLine("Connected to Oracle");
    }
    
    public void Query(string query)
    {
        Console.WriteLine($"Query: {query}");
    }
}
```

Uygulamada, Strategy deseni kullanılarak farklı veritabanı stratejileri oluşturuldu. İstemci kod, istediği veritabanı
stratejisini seçerek farklı veritabanlarına bağlanabilir ve sorgular yapabilir.

Bu örnek, uygulamanın yeni veritabanı türleri eklemesi gerektiğinde daha esnek ve yönetilebilir bir yapıya sahip
olmasını sağlar. Aynı zamanda, istemci kodunun farklı veritabanı erişim stratejilerini kullanması ve değiştirmesi de
kolaylaşır.