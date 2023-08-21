# Decorator Tasarım Deseni
Decorator tasarım deseni, nesnelere dinamik olarak davranışlar eklemek ve bu davranışları farklı kombinasyonlarda birleştirmek için kullanılan bir yapısal tasarım desenidir. Bu desen, nesneleri değiştirmeden veya alt sınıfları oluşturmadan davranışlarını genişletmeye olanak tanır. Bu sayede esnek ve modüler kod yapısı oluşturabilirsiniz.

## Avantajları
Decorator tasarım deseninin bazı avantajları şunlardır:

- **Esneklik ve Modülerlik**: Decorator deseni, nesnelerin davranışlarını dinamik olarak değiştirmeyi ve özelleştirmeyi sağlayarak esnek ve modüler bir yapı oluşturmanıza yardımcı olur.

- **Açık Kapalı İlkesi**: Yeni davranışları eklemek, mevcut kodu değiştirmeden yapılabilir. Bu, kodun açık kapalı ilkesine uygunluğunu korur.

- **Birleştirilebilir Davranışlar**: Decorator deseni, farklı davranışları özelleştirmeyi ve istediğiniz gibi birleştirmeyi sağlar. Bu sayede çeşitli kombinasyonlar oluşturabilirsiniz.

## Örnek Uygulama: Bildirim Yönetimi
Aşağıda, Decorator tasarım deseninin somut bir örneği verilmiştir: Farklı bildirim türlerini (Facebook, SMS, E-posta) özelleştirerek birleştiren bir bildirim yönetim sistemi. Bu örnekte, temel bildirim nesnesine farklı dekoratörler eklenerek farklı bildirim kombinasyonları oluşturulmaktadır.

### Kod Örneği
Öncelikle, bildirim nesnesini temsil eden `INotification` arayüzünü oluşturalım:

```C#
public interface INotification
{
    void Send(string message);
}
```

Ardından, bildirim nesnesini temsil eden `BaseNotification` sınıfını oluşturalım:

```C#
public class BaseNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Base Notification: {message}");
    }
}
```

Sonrasında, decorator sınıfını temsil eden `NotificationDecorator` sınıfını oluşturalım:

```C#
public abstract class NotificationDecorator : INotification
{
    private INotification _notification;

    public NotificationDecorator(INotification notification)
    {
        _notification = notification;
    }

    public virtual void Send(string message)
    {
        _notification.Send(message);
    }
}
```

Ardından, farklı bildirim türlerini temsil eden `FacebookNotificationDecorator`, `SmsNotificationDecorator` ve `EmailNotificationDecorator` sınıflarını oluşturalım:

```C#
public class FacebookNotificationDecorator : NotificationDecorator
{
    public FacebookNotificationDecorator(INotification notification) : base(notification)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Facebook Notification: {message}");
    }
}

public class SmsNotificationDecorator : NotificationDecorator
{
    public SmsNotificationDecorator(INotification notification) : base(notification)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"SMS Notification: {message}");
    }
}

public class EmailNotificationDecorator : NotificationDecorator
{
    public EmailNotificationDecorator(INotification notification) : base(notification)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"E-mail Notification: {message}");
    }
}
```

Son olarak, `Program` sınıfında oluşturduğumuz sınıfları kullanarak bir bildirim yönetim sistemi oluşturalım:

```C#
bool isFacebookNotification = true, isEmailNotification = true;

INotification notification = new BaseNotification();
notification = new SMSNotificationDecorator(notification);

if (isFacebookNotification)
{
    notification = new FacebookNotificationDecorator(notification);
}

if (isEmailNotification)
{
    notification = new EmailNotificationDecorator(notification);
}

notification.Send("Hello World!");
```

### Ekran Çıktısı

```
Base Notification: Hello World!
SMS Notification: Hello World!
Facebook Notification: Hello World!
E-mail Notification: Hello World!
```

Sonuç olarak, yukarıdaki ekran çıktısında görüldüğü gibi, farklı bildirim türlerini özelleştirerek birleştirebildik. Bu sayede, farklı bildirim kombinasyonları oluşturabildik.