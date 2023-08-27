# Prototype Design Pattern

Prototype Design Pattern, nesnelerin kopyalanmasını ve yeni nesnelerin oluşturulmasını sağlayan bir tasarım desenidir. Bu desen, nesne oluşturma sürecini daha dinamik ve esnek hale getirerek nesnelerin farklı varyasyonlarının yaratılmasını kolaylaştırır.

Bir uygulamada, var olan bir nesneyi kopyalayarak yeni bir nesne oluşturma ihtiyacı olabilir. Aynı zamanda, bu kopyalama işlemi varyasyonlar veya farklı bağlamlar için de uygulanabilir olmalıdır. Prototype Design Pattern, nesne oluşturma sürecini ayrıştırarak mevcut nesnelerin kopyalanmasını ve varyasyonlarının oluşturulmasını kolaylaştırır.

## Avantajları

- **Nesne Kopyalama**: Bir nesneyi kopyalayarak yeni bir nesne oluşturmak, bu desen ile daha kolay hale gelir.

- **Varyasyonlar Oluşturma**: Var olan nesnelerin kopyalanmasıyla farklı varyasyonlar yaratılabilir.

- **Nesne Oluşturma Sürecinin Soyutlanması**: Nesne oluşturma süreci, sınıf hiyerarşisi içinde ayrı bir arayüze veya sınıfa taşınarak daha soyut bir yapıya kavuşturulabilir.

## Örnek Senaryo

Bir örnek senaryoda, bir araç üretimini ele alalım. Farklı türde araçlar (örneğin otomobiller, kamyonetler) aynı temel özelliklere sahip olabilir ancak bazı detaylarda farklılıklar gösterebilir. Prototype Design Pattern, var olan bir aracı kopyalayarak yeni türde araçlar yaratmayı sağlar. Bu sayede benzer özelliklere sahip araçları farklı varyasyonlarda üretmek kolaylaşır.

### Örnek Kod

Örnek senaryoyu kod ile ele alalım. Öncelikle, araçların ortak özelliklerini tanımlayan bir `Vehicle` sınıfı oluşturalım.

```csharp
public class Vehicle : ICloneable
{
    public string Model { get; set; }
    public string Color { get; set; }
    public string Type { get; set; }
    
    public ICloneable Clone()
    {
        return (ICloneable)MemberwiseClone();    
    }
    
    public void Display()
    {
        Console.WriteLine($"Model: {Model}, Color: {Color}, Type: {Type}");
    }
}
```

`Vehicle` sınıfı, `ICloneable` arayüzünü uygulayarak kopyalanabilir olmasını sağlar. Ayrıca, `Clone` metodu ile nesnenin kopyasını oluşturur. `Display` metodu ile de nesnenin özellikleri ekrana yazdırılır.


```csharp
public interface ICloneable
{
    ICloneable Clone();
}
```

Son olarak, `Program.cs` içerisinde `Vehicle` sınıfından bir nesne oluşturup kopyalayalım. Kopyalanan nesnenin özelliklerini değiştirerek farklı bir varyasyon oluşturalım.

```csharp
Vehicle originalCar = new Vehicle { Type = "Car", Model = "Sedan", Color = "Red"};
originalCar.Display();

Vehicle clonedCar = (Vehicle)originalCar.Clone();
clonedCar.Model = "SUV";
clonedCar.Display();
```

### Çıktı

```
Model: Sedan, Color: Red, Type: Car
Model: SUV, Color: Red, Type: Car
```