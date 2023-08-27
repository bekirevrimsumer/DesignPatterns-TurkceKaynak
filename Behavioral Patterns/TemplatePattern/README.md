# Template Design Pattern

Template Design Pattern, bir sürecin genel yapısını tanımlar ve bu süreç içerisindeki adımları alt sınıflara bırakarak daha özelleştirilmiş davranışları destekler. Bu desen, bir algoritmanın temel adımlarını belirlemek için kullanılırken, alt sınıfların belirli adımları uygulayarak algoritmayı özelleştirmesine olanak tanır.

## Neden Template Design Pattern?
Birçok işlem benzer adımlara sahip olabilir ancak alt adımlar farklılık gösterebilir. Bu durumda her işlem için ayrı ayrı kod yazmak yerine Template Design Pattern kullanmak, kod tekrarını önler ve bakımı kolaylaştırır. Aynı zamanda yeni işlemler eklemek veya mevcut işlemleri değiştirmek istediğinizde, sadece alt sınıfları uyarlayarak değişiklik yapmanız yeterli olur.

## Avantajlar
- **Kod Tekrarını Azaltır**: Temel adımları tek bir yerde tanımlayarak kod tekrarını önler.
- **Özelleştirilebilirlik**: Alt sınıflar, temel adımları koruyarak kendi özelleştirilmiş adımlarını uygulayabilir.
- **Miras Yoluyla Esneklik**: Alt sınıfların temel adımları miras alması, kodun genişletilebilirliğini artırır.
- **Bakım Kolaylığı**: Değişiklikler sadece alt sınıflarda yapılır, bu da kodun bakımını kolaylaştırır.

## Örnek Senaryo
Bu senaryoda, bir kahve ve çay yapım işlemini ele alacağız. Her iki işlem de temel adımları paylaşırken, kahve ve çayın özelleştirilmiş adımları farklılık göstermektedir.

### Örnek Kod

Öncelikle temel adımları içeren bir sınıf oluşturuyoruz. Bu sınıf, kahve ve çay sınıflarının miras alacağı sınıf olacak.

```csharp
public abstract class HotDrinkTemplate
{
    public void MakeHotDrink()
    {
        BoilWater();
        BrewCoffee();
        PourInCup();
        AddCondiments();
    }
    
    protected void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }
    
    protected abstract void BrewCoffee();
    
    protected void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }
    
    protected abstract void AddCondiments();
}
```

Daha sonra kahve ve çay sınıflarını oluşturuyoruz. Bu sınıflar, temel adımları miras alarak kendi özelleştirilmiş adımlarını uygulayacak.

```csharp
public class Coffee : HotDrinkTemplate
{
    protected override void BrewCoffee()
    {
        Console.WriteLine("Dripping coffee through filter");
    }
    
    protected override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk");
    }
}
```

```csharp

public class Tea : HotDrinkTemplate
{
    protected override void BrewCoffee()
    {
        Console.WriteLine("Steeping the tea");
    }
    
    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon");
    }
}
```

Son olarak, kahve ve çay sınıflarını kullanarak bir kahve ve çay yapım işlemi gerçekleştiriyoruz.

```csharp
var coffee = new Coffee();
coffee.MakeHotDrink();

var tea = new Tea();
tea.MakeHotDrink();
```

Örnekte de görüldüğü gibi, kahve ve çay sınıfları temel adımları miras alarak kendi özelleştirilmiş adımlarını uyguladı. Bu sayede, temel adımları tekrar yazmaktan kurtulduk ve kod tekrarını önledik.

