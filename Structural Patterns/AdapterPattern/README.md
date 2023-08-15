# Adapter Design Pattern

Adapter Design Pattern, farklı arayüzleri veya yapıları olan sınıfları bir araya getirmek ve uyumsuzlukları gidermek için kullanılan bir tasarım desenidir. Bu desen, mevcut kodu değiştirmeden farklı bileşenlerin birlikte çalışmasını sağlar. Temel amacı, farklı arabirimlere sahip nesnelerin işbirliği yapabilmesini sağlamaktır.

Bu desen, özellikle mevcut bir sisteme yeni bir bileşen entegre edilmesi gerektiğinde veya farklı sistemler arasında veri dönüşümü gerektiğinde faydalıdır. Yeni bileşenlerin veya yapıların, mevcut yapılarla uyumlu hale getirilmesi ve sorunsuz bir şekilde entegre edilmesi gerektiğinde Adapter deseni kullanılır.

## Neden Adapter Design Pattern Kullanılır?

- **Uyumlu Olmayan Arayüzler**: Farklı alt sistemler veya bileşenler, farklı arayüzler kullanabilir. Bu durum, bu sistemleri doğrudan birleştirmeyi zorlaştırır. Adapter tasarım deseni, bu uyumsuzluğu gidererek farklı bileşenlerin bir arada çalışmasını sağlar.

- **Varolan Kodun Korunması**: Mevcut bir kod tabanı üzerine yeni bileşenler eklemek veya dışarıdan gelen kaynakları entegre etmek gerektiğinde, varolan kodun değiştirilmeden uyumlu hale getirilmesi önemlidir. Adapter deseni, varolan kodu koruyarak yeni bileşenlerin entegrasyonunu kolaylaştırır.

- **Yeniden Kullanım ve Bakım Kolaylığı**: Adapter, farklı alt sistemlerdeki mevcut kodları tekrar yazmadan ve daha önce yazılan kodları tekrar kullanarak yeni sistemlere uyum sağlar. Bu, bakımı ve geliştirmeyi kolaylaştırır.

## Adapter Design Pattern Örneği: Veritabanı Adaptörü

Bu örnek, Adapter Design Pattern'in nasıl kullanılabileceğini gösteren basit bir senaryoyu ele almaktadır. Farklı veritabanı sistemleri farklı API'lar veya bağlantı yöntemleri kullanabilir. Uygulamanın bu farklı sistemleri aynı arayüz üzerinden kullanması gerektiğinde, Adapter tasarım deseni devreye girer.

### Adapter Design Pattern'i Uygulamadan Önceki Durum

İlk önce Adapter Design Pattern kullanmadan önceki durumu ele alalım. Aşağıdaki örnekte, SqlDatabase ve NoSqlDatabase sınıfları, farklı veritabanı sistemlerini temsil eder. Her iki sınıf da farklı API'lar veya bağlantı yöntemleri kullanır. SqlDatabase sınıfı, Query() yöntemini kullanarak SQL sorgularını çalıştırırken, NoSqlDatabase sınıfı, Find() yöntemini kullanarak NoSQL sorgularını çalıştırır.

```csharp
public class SqlDatabase
{
    public void Query(string query)
    {
        Console.WriteLine($"SQL: {query}");
    }
}

public class NoSqlDatabase
{
    public void Find(string query)
    {
        Console.WriteLine($"NoSQL: {query}");
    }
}
```

Uygulama, SqlDatabase ve NoSqlDatabase sınıflarını kullanarak farklı veritabanı sistemlerini kullanabilir. Ancak, uygulama, farklı veritabanı sistemlerini kullanmak için her biri için ayrı kod yazmak zorunda kalır. Bu, uygulamanın farklı veritabanı sistemlerini kullanmasını zorlaştırır. Ayrıca, uygulama, farklı veritabanı sistemlerini kullanmak için her biri için ayrı kod yazmak zorunda kalır. Bu, uygulamanın farklı veritabanı sistemlerini kullanmasını zorlaştırır.

```csharp
var sqlDatabase = new SqlDatabase();
sqlDatabase.Query("SELECT * FROM Customers");

var noSqlDatabase = new NoSqlDatabase();
noSqlDatabase.Find("SELECT * FROM Customers");
```
### Adapter Design Pattern Kullanımı

Adapter Design Pattern kullanarak, farklı veritabanı sistemlerini aynı arayüz üzerinden kullanabiliriz. Örneğimizde, SqlDatabase ve NoSqlDatabase sınıfları farklı API'lar veya bağlantı yöntemleri kullanıyor. Bu uyumsuzluğu gidermek için, her iki sınıfı da IDatabaseAdapter arayüzüne uyan SqlDatabaseAdapter ve NoSqlDatabaseAdapter sınıfları ile adapte ediyoruz. Bu sayede uygulama, farklı veritabanı sistemlerini aynı arayüz üzerinden kullanabilir.

1. Arabirimler:
   

```csharp
public interface IDatabaseAdapter
{
    void ExecuteQuery(string query);
}
```

2. Farklı Veritabanı Sistemleri:

```csharp
public class SqlDatabase
{
    public void Query(string query)
    {
        Console.WriteLine($"SQL: {query}");
    }
}

public class NoSqlDatabase
{
    public void Find(string query)
    {
        Console.WriteLine($"NoSQL: {query}");
    }
}
```

3. Adapter Sınıfları:

```csharp

public class SqlDatabaseAdapter : IDatabaseAdapter
{
    private readonly SqlDatabase _sqlDatabase;

    public SqlDatabaseAdapter(SqlDatabase sqlDatabase)
    {
        _sqlDatabase = sqlDatabase;
    }

    public void ExecuteQuery(string query)
    {
        _sqlDatabase.Query(query);
    }
}

public class NoSqlDatabaseAdapter : IDatabaseAdapter
{
    private readonly NoSqlDatabase _noSqlDatabase;

    public NoSqlDatabaseAdapter(NoSqlDatabase noSqlDatabase)
    {
        _noSqlDatabase = noSqlDatabase;
    }

    public void ExecuteQuery(string query)
    {
        _noSqlDatabase.Find(query);
    }
}
```

4. Kullanım:

```csharp
var sqlDatabaseAdapter = new SqlDatabaseAdapter(new SqlDatabase());
sqlDatabaseAdapter.ExecuteQuery("SELECT * FROM Customers");

var noSqlDatabaseAdapter = new NoSqlDatabaseAdapter(new NoSqlDatabase());
noSqlDatabaseAdapter.ExecuteQuery("SELECT * FROM Customers");
```

Bu örnek, Adapter tasarım deseninin ne zaman ve nasıl kullanılabileceğini göstermektedir. İki farklı yapıdaki sistemlerin, mevcut bir arayüze uyacak şekilde adapte edilmesini sağlayarak, kodun daha esnek, sürdürülebilir ve yeniden kullanılabilir olmasını sağlar.
