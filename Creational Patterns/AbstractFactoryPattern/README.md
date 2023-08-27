# Abstract Factory Design Pattern

Abstract Factory Design Pattern, ilişkili nesnelerin ailesini oluşturmak ve bu nesneleri oluştururken ilgili ürünlerin birbiriyle uyumlu olduğunu sağlamak için kullanılan bir tasarım desenidir. Bu desen, somut sınıfların oluşturulmasını soyutlar ve farklı türde nesnelerin aynı ailede bir arada çalışmasını kolaylaştırır.

Bir uygulamada farklı türde nesnelerin bir arada çalışması gerekebilir. Özellikle bu nesneler bir aile içinde gruplandırılmışsa, Abstract Factory Design Pattern kullanmak uygun bir çözüm olabilir. Bu desen, aynı ailede bulunan nesnelerin oluşturulma işlemlerini soyutlamak ve nesnelerin birbiriyle uyumlu olduğunu sağlamak amacıyla kullanılır.


## Avantajları

Abstract Factory tasarım deseninin avantajları şunlar olabilir:

- **Esneklik**: Abstract Factory, farklı türde nesneleri oluşturmayı soyutlar ve bu sayede uygulamanın daha esnek ve genişletilebilir olmasını sağlar.

- **Uyumlu Nesneler**: Birbirine uyumlu nesneleri bir araya getirerek hataların ve uyumsuzlukların önüne geçer.

- **İstemci Bağımsızlığı**: İstemci kod, somut sınıflara doğrudan bağlı olmadığı için gelecekteki değişikliklere karşı daha dayanıklı hale gelir.

## Örnek Senaryo



### Örnek Kod

Öncelikle `Command` ve `Connection` isimli abstract sınıflarımızı oluşturalım. Bu sınıfların içerisinde abstract metotlarımızı tanımlayalım.

```csharp
public abstract class Command
{
    public abstract void ExecuteCommand(string query);
}

public abstract class Connection
{
    public abstract void OpenConnection();
    public abstract void CloseConnection();
}
```

Daha sonra `MySqlCommand`, `MySqlConnection`, `PostgreSqlCommand` ve `PostgreSqlConnection` isimli sınıflarımızı oluşturalım. Bu sınıflar, `Command` ve `Connection` sınıflarından türer ve abstract metotları override eder.

```csharp
public class MySqlCommand : Command
{
    public override void ExecuteCommand(string query)
    {
        Console.WriteLine("MySql Command: " + query);
    }
}

public class MySqlConnection : Connection
{
    public override void OpenConnection()
    {
        Console.WriteLine("MySql Connection Opened");
    }

    public override void CloseConnection()
    {
        Console.WriteLine("MySql Connection Closed");
    }
}

public class PostgreSqlCommand : Command
{
    public override void ExecuteCommand(string query)
    {
        Console.WriteLine("PostgreSql Command: " + query);
    }
}

public class PostgreSqlConnection : Connection
{
    public override void OpenConnection()
    {
        Console.WriteLine("PostgreSql Connection Opened");
    }

    public override void CloseConnection()
    {
        Console.WriteLine("PostgreSql Connection Closed");
    }
}
```

Sonrasında `IDatabaseFactory` isimli interface'imizi oluşturalım. Bu interface, `CreateCommand` ve `CreateConnection` isimli metotları içermelidir.

```csharp
public interface IDatabaseFactory
{
    Connection CreateConnection();
    Command CreateCommand();
}
```

Daha sonra `MySqlDatabaseFactory` ve `PostgreSqlDatabaseFactory` isimli sınıflarımızı oluşturalım. Bu sınıflar, `IDatabaseFactory` interface'inden türer ve interface içerisindeki metotları override eder.

```csharp
public class MySqlDatabaseFactory : IDatabaseFactory
{
    public Connection CreateConnection()
    {
        return new MySqlConnection();
    }

    public Command CreateCommand()
    {
        return new MySqlCommand();
    }
}

public class PostgreSqlDatabaseFactory : IDatabaseFactory
{
    public Connection CreateConnection()
    {
        return new PostgreSqlConnection();
    }

    public Command CreateCommand()
    {
        return new PostgreSqlCommand();
    }
}
```

Son olarak `DatabaseOperation` isimli sınıfımızı oluşturalım.

```csharp
public class DatabaseOperation
{
    IDatabaseFactory _databaseFactory;
    Connection _connection;
    Command _command;
    
    public DatabaseOperation(IDatabaseFactory databaseFactory)
    {
        _databaseFactory = databaseFactory;
        _connection = _databaseFactory.CreateConnection();
        _command = _databaseFactory.CreateCommand();
    }
    
    public void Add(string query)
    {
        _connection.Connect();
        _command.ExecuteCommand(query);
        _connection.Disconnect();
    }
    
    public void Update(string query)
    {
        _connection.Connect();
        _command.ExecuteCommand(query);
        _connection.Disconnect();
    }
    
    public void Delete(string query)
    {
        _connection.Connect();
        _command.ExecuteCommand(query);
        _connection.Disconnect();
    }
}
```

`DatabaseOperation` sınıfı, `IDatabaseFactory` interface'inden türeyen sınıfların nesnelerini alır ve bu nesneleri kullanarak veritabanı işlemlerini gerçekleştirir.

### Örnek Kullanım

```csharp
var mySqlOperation = new DatabaseOperation(new MySqlDatabaseFactory());
mySqlOperation.Add("INSERT INTO table VALUES (1, 'MySql')");
mySqlOperation.Update("UPDATE table SET name = 'MySql' WHERE id = 1");
mySqlOperation.Delete("DELETE FROM table WHERE id = 1");

var postgreSqlOperation = new DatabaseOperation(new PostgreSqlDatabaseFactory());
postgreSqlOperation.Add("INSERT INTO table VALUES (1, 'PostgreSql')");
postgreSqlOperation.Update("UPDATE table SET name = 'PostgreSql' WHERE id = 1");
postgreSqlOperation.Delete("DELETE FROM table WHERE id = 1");
```