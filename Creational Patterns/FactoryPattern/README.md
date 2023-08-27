# Factory Design Pattern

Factory Design Pattern (Fabrika Tasarım Deseni), nesne oluşturmayı merkezi hale getirerek istemcilerin nesneleri doğrudan oluşturmasını engellemeyi amaçlar. Bu desen, somut nesne oluşturmayı soyutlamak ve istemcilerin nesne oluşturma detaylarına karşı korunmasını sağlamak için kullanılır.

Nesne oluşturma işlemi, uygulama içinde birden fazla yerde tekrar edebilir ve nesne türleri değişebilir. Factory Design Pattern, bu tür durumları ele almak ve aynı zamanda daha temiz ve düzenli bir kod yapısı oluşturmak için kullanılır.

## Avantajları

Factory tasarım deseni, aşağıdaki avantajları sağlar:

- **Kod Tekrarını Azaltır**: Nesne oluşturma mantığı tekrar etmek yerine, bu işlemi merkezi bir Factory sınıfında gerçekleştirerek kodun tekrarını azaltır.

- **Esneklik ve Genişletilebilirlik**: Yeni nesne türleri eklemek veya mevcut nesne oluşturma mantığını değiştirmek istediğinizde sadece Factory sınıfını güncellemeniz yeterli olur.

- **Bağımlılıkları Azaltır**: İstemciler, nesne oluşturma ayrıntılarından soyutlandığı için somut sınıflara doğrudan bağımlılık azalır.

- **Mantıklı İsimlendirme**: Nesne oluşturmayı bir Factory ile yapmak, oluşturulan nesnenin hangi amaca hizmet ettiğini daha anlamlı şekillerde ifade etmenizi sağlar.

## Örnek Senaryo

Elimizde bir bildirim (notification) sistemi olduğunu düşünelim. Bu sistemde kullanıcılara farklı yollarla (e-posta, SMS, Slack) bildirimler göndermek istiyoruz. Bu senaryoda Factory Design Pattern, farklı türde bildirim nesnelerini oluşturmak için kullanılabilir.

## Örnek Kod

Örnek kodumuzda, bildirim sistemi için bir `INotification` interface'i ve bu interface'den türeyen `EmailNotification`, `SmsNotification` ve `SlackNotification` sınıfları bulunuyor. Bu sınıfların hepsi `INotification` interface'inden türediği için, `INotification` sınıfı üzerinden nesne oluşturmak mümkün. Ancak bu durumda, istemci sınıfın bildirim türüne göre nesne oluşturması gerekiyor. Bu durumda Factory Design Pattern kullanarak, istemci sınıfın bildirim türüne göre nesne oluşturmasını engelleyebiliriz.

```csharp
public interface INotification
{
    void Notify(User user, string message);
}
```

```csharp
public class EmailNotification : INotification
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Sending email to {user.Email}...");
    }
}
```

```csharp
public class SmsNotification : INotification
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Sending SMS to {user.PhoneNumber}...");
    }
}
```

```csharp
public class SlackNotification : INotification
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Sending Slack message to {user.SlackId}...");
    }
}
```

Factory Design Pattern için `INotificationFactory` interface'i oluşturuyoruz. Bu interface'den türeyen `NotificationFactory` sınıfı, bildirim türüne göre nesne oluşturmak için kullanılacak.

```csharp
public interface INotificationFactory
{
    INotification CreateNotification(NotificationType type);
}
```

```csharp
public class NotifyFactory : INotifyFactory
{
    public INotification CreateNotification(NotifyType notificationType)
    {
        return notificationType switch
        {
            NotifyType.Sms => new SmsNotification(),
            NotifyType.Email => new EmailNotification(),
            NotifyType.Slack => new SlackNotification(),
            _ => throw new ArgumentException("Invalid notification type", nameof(notificationType))
        };
    }
}
```

`NotifyFactory` sınıfı, `INotificationFactory` interface'inden türediği için, `INotificationFactory` interface'i üzerinden nesne oluşturmak mümkün. Bu sayede istemci sınıfın bildirim türüne göre nesne oluşturması engellenmiş oluyor.

```csharp
public enum NotifyType
{
    Sms,
    Email,
    Slack
}
```

```csharp
public class NotificationService
{
    private readonly INotificationFactory _notificationFactory;

    public NotificationService(INotificationFactory notificationFactory)
    {
        _notificationFactory = notificationFactory;
    }

    public void SendNotification(User user, string message, NotifyType notifyType)
    {
        var notification = _notificationFactory.CreateNotification(notifyType);
        notification.Notify(user, message);
    }
}
```

```csharp
public class User
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string SlackId { get; set; }
}
```

```csharp
var notificationService = new NotificationService(new NotifyFactory());

var user = new User { Email = "test@test.com ", PhoneNumber = "123456789", SlackId = "1234" };

notificationService.SendNotification(user, "Hello World!", NotifyType.Email);
notificationService.SendNotification(user, "Hello World!", NotifyType.Sms);
notificationService.SendNotification(user, "Hello World!", NotifyType.Slack);
```

Örnekte de görüldüğü gibi, istemci sınıfın bildirim türüne göre nesne oluşturması engellenmiş oldu. Bu sayede istemci sınıf, bildirim türüne göre nesne oluşturmak için `INotificationFactory` interface'ini kullanıyor. Böylece daha temiz ve düzenli bir kod yapısı oluşturmuş olduk.