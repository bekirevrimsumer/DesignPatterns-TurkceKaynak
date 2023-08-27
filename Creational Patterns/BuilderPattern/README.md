# Builder Design Pattern

Builder Design Pattern, karmaşık nesnelerin adım adım oluşturulmasını ve bu sürecin farklı adımlarının ayrıştırılmasını sağlayan bir tasarım desenidir. Bu desen, nesne oluşturma sürecinin ayrı bir sınıf hiyerarşisi içinde yönetilmesini ve farklı bileşenlerin bir araya gelerek nesnelerin oluşturulmasını sağlar.

Bir nesnenin oluşturulma süreci karmaşık ve birden fazla adımdan oluşuyorsa, Builder Design Pattern kullanmak faydalı olabilir. Bu desen, nesne oluşturma sürecini adım adım yöneterek nesnelerin farklı varyasyonlarını oluşturmayı kolaylaştırır.

## Avantajları

Builder tasarım deseninin avantajları şunlar olabilir:

- **Karmaşıklığı Azaltır**: Karmaşık nesnelerin oluşturulma sürecini ayrıştırarak, her bir adımın ayrı sınıflarda yönetilmesini sağlar.

- **Esneklik**: Farklı varyasyonlara sahip nesnelerin oluşturulması gerektiğinde, farklı builder sınıfları oluşturarak bu varyasyonları kolayca yönetebilirsiniz.

- **Okunabilirlik ve Bakım Kolaylığı**: Nesne oluşturmanın adımları ayrı sınıflarda yer aldığı için, kodun daha okunabilir ve bakımı daha kolay olur.

## Örnek Senaryo

Örnek senaryoda bir pizza yapımını ele alalım. Pizzalar farklı hamur, sos ve malzemelerle yapılabileceği için nesnenin oluşturulma süreci karmaşıktır. Builder Design Pattern, hamur, sos ve malzemelerin adım adım oluşturulmasını ve farklı türde pizzaların kolayca yaratılmasını sağlar.

### Örnek Kod

Öncelikle `Pizza` sınıfını oluşturalım.

```csharp
public class Pizza
{
    public string Dough { get; set; }
    public string Sauce { get; set; }
    public string Topping { get; set; }

    public void Display()
    {
        Console.WriteLine($"Dough: {Dough}, Sauce: {Sauce}, Topping: {Topping}");
    }
}
```
Sonrasında `IPizzaBuilder` interface'ini oluşturalım. Bu arayüz, pizza nesnesinin oluşturulma sürecini yönetecek olan interface'dir.

```csharp
public interface IPizzaBuilder
{
    public void SetDough();
    public void SetSauce();
    public void SetTopping();
    public Pizza GetPizza();
}
```

`IPizzaBuilder` interface'ini implemente eden `HawaiianPizzaBuilder` sınıfını oluşturalım.

```csharp
public class HawaiianPizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void SetDough()
    {
        _pizza.Dough = "cross";
    }

    public void SetSauce()
    {
        _pizza.Sauce = "mild";
    }

    public void SetTopping()
    {
        _pizza.Topping = "ham+pineapple";
    }

    public Pizza GetPizza()
    {
        return _pizza;
    }
}
```

Son olarak `CookManager` sınıfını oluşturalım.

```csharp
public class CookManager
{
    private IPizzaBuilder _pizzaBuilder;
    
    public CookManager(IPizzaBuilder pizzaBuilder)
    {
        _pizzaBuilder = pizzaBuilder;
    }
    
    public void MakePizza()
    {
        _pizzaBuilder.SetDough();
        _pizzaBuilder.SetSauce();
        _pizzaBuilder.SetTopping();
    }
    
    public Pizza GetPizza()
    {
        return _pizzaBuilder.GetPizza();
    }
}
```

### Örnek Kullanım

Örnek kullanım için `Program.cs` dosyasını aşağıdaki gibi düzenleyebiliriz.

```csharp
IPizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
CookManager cook = new CookManager(hawaiianPizzaBuilder);

cook.MakePizza();
Pizza pizza = cook.GetPizza();
pizza.Display();
```

### Çıktı

```
Dough: cross, Sauce: mild, Topping: ham+pineapple
```

Örnekte de görüldüğü üzere `HawaiianPizzaBuilder` sınıfı, `Pizza` nesnesinin oluşturulma sürecini yönetmektedir. `CookManager` sınıfı, `IPizzaBuilder` interface'ini implemente eden sınıfları kullanarak nesnenin oluşturulma sürecini yönetmektedir. Bu sayede `Pizza` nesnesinin oluşturulma süreci ayrıştırılmış ve farklı varyasyonlara sahip pizzaların oluşturulması kolaylaşmıştır.