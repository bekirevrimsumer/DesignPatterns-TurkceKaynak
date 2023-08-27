# State Design Pattern

State tasarım deseni, bir nesnenin davranışını nesnenin durum değişikliklerine göre değiştirmenin bir yolunu sağlayan bir tasarım desenidir. Bu desen, özellikle bir nesnenin farklı durumlarına sahip olduğu durumlarda kod tekrarını azaltmak, sınıflar arasındaki bağımlılığı azaltmak ve sürdürülebilir bir yapı oluşturmak için kullanılır. State tasarım deseni, bir durum makinesi olarak düşünülebilir ve nesnenin durumu değiştikçe davranışları da değişir.

### Neden Kullanılır?
State tasarım deseni şu durumlarda kullanışlıdır:

- **Nesnenin Durumları**: Bir nesnenin farklı durumlarına sahip olduğu durumda State deseni kullanılabilir. Bu durum, nesnenin davranışının farklı durumlar arasında değiştiği durumlarda ortaya çıkar.

- **Durum Geçişleri**: Nesnenin farklı durumlar arasında geçişler yapması gerekiyorsa, bu geçişleri düzenlemek için State deseni kullanılabilir. Bu sayede durum geçişlerinin yönetimi kolaylaşır.

- **Duruma Özgü Davranışlar**: Her durumun kendi davranışlarına sahip olduğu karmaşık senaryolarda State deseni kullanarak her durumun davranışını ayrı ayrı tanımlayabiliriz.

- **Yeni Durum Ekleme**: Sisteme yeni bir durum eklendiğinde mevcut kodun değiştirilmesini önler, böylece Open/Closed prensibine uyulmuş olur.

### Sorunları Nasıl Çözer?
State tasarım deseni aşağıdaki sorunları çözmeye yardımcı olur:

- **Kod Tekrarı Azaltma**: Farklı durumlar arasında paylaşılan davranışlar varsa, bu davranışları tekrar etmek yerine State deseni kullanarak bu davranışları ortak bir yerde tanımlayabiliriz.

- **Esneklik ve Genişletilebilirlik**: Yeni durumlar eklemek veya mevcut durum davranışlarını değiştirmek gerektiğinde, sadece ilgili durum sınıfını güncellemek yeterlidir. Bu, sistemin daha esnek ve genişletilebilir olmasını sağlar.

- **Bağımlılıkları Azaltma**: Durumlar arasındaki geçişler veya duruma özgü davranışlar nedeniyle oluşan sıkı bağımlılıkları azaltır. Bu, kodun daha bakımı kolay ve anlaşılır hale gelmesini sağlar.

### Örnek Uygulama

Bir belge yönetim sistemi düşünün. Bu sistemde belgelerin farklı durumları olabilir. Örneğin, bir belge oluşturulduğunda durumu "Taslak" olabilir. Daha sonra belgeyi düzenlemeye başladığımızda durumu "Düzenleniyor" olabilir. Belge bir incelemeden geçtiğinde durumu "İnceleniyor" olabilir. Bu durumlar arasında geçişler yapmak gerekebilir.

Öncelikle `IState` interface'ini oluşturalım. Bu interface, belge durumlarının uygulaması gereken davranışları tanımlar.

```C#
public interface IState
{
    void Publish(Document document);
}
```

`IState` interface'ini uygulayan `DraftState`, `ReviewState` ve `PublishedState` sınıflarını oluşturalım. Bu sınıflar, belge durumlarına özgü davranışları tanımlar.

```C#
public class DraftState : IState
{
    public void Publish(Document document)
    {
        Console.WriteLine("Document is in draft state. Cannot publish.");
        document.ChangeState(new ReviewState());
        document.Publish();
    }
}

public class ReviewState : IState
{
    public void Publish(Document document)
    {
        Console.WriteLine("Document is in review state. Cannot publish.");
        document.ChangeState(new PublishedState());
        document.Publish();
    }
}

public class PublishedState : IState
{
    public void Publish(Document document)
    {
        Console.WriteLine("Document is published.");
    }
}
```

`Document` sınıfını oluşturalım. Bu sınıf, belge durumlarını yönetir.

```C#

public class Document
{
    private IState _state;

    public Document()
    {
        _state = new DraftState();
    }

    public void ChangeState(IState state)
    {
        _state = state;
    }

    public void Publish()
    {
        _state.Publish(this);
    }
}
```

`Document` sınıfını kullanarak bir belgeyi yayınlayalım.

```C#

var document = new Document();
document.Publish();
```

**Çıktı**
```
Document is in draft state. Cannot publish.
Document is in review state. Cannot publish.
Document is published.
```

Örnekte görüldüğü gibi, belge durumlarına özgü davranışlar `IState` interface'ini uygulayan sınıflarda tanımlanmıştır. `Document` sınıfı, belge durumlarını yönetir ve belge durumları arasında geçişleri sağlar.

