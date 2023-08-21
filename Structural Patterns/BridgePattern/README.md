# Bridge Tasarım Deseni

Bridge tasarım deseni, birbirine bağlı iki ayrı hiyerarşinin birbirinden bağımsız olarak geliştirilmesine olanak tanır. Bu desen, soyutlamayı ve gerçek uygulamayı ayırmayı sağlayarak esnek ve modüler bir yapı oluşturmanıza yardımcı olur. İki farklı hiyerarşiyi birbirine bağlamak yerine, bu iki hiyerarşiyi ayrı ayrı geliştirip daha sonra köprü (bridge) arayüzü ile birleştirerek iletişim kurmalarını sağlar.

## Avantajları
Bridge tasarım deseninin bazı avantajları şunlardır:

- **Esneklik ve Genişletilebilirlik**: Bridge deseni, soyutlama ve gerçek uygulamanın ayrılmasını sağlayarak her iki tarafın da bağımsız olarak geliştirilmesine olanak tanır. Bu sayede yeni soyutlama ve uygulama sınıfları eklemek kolaylaşır.

- **Değişiklikleri Azaltma**: Bir tarafta yapılan değişiklikler diğer taraftaki yapıları etkilemez. Bu, kodun daha az etkileşimli ve bakımının daha kolay olmasını sağlar.

- **Kodu Daha Anlaşılır Hale Getirme**: Soyutlama ve uygulama ayrımı, kodun daha modüler ve anlaşılır olmasını sağlar. Bu sayede karmaşıklık azalır.

- **Alt Sistemlerin Bağımsız Geliştirilmesi**: Alt sistemler (soyutlama ve gerçek uygulama) farklı ekibler veya geliştiriciler tarafından bağımsız olarak geliştirilebilir.

## Örnek Senaryo

Diyelim ki bir oyun geliştiriyorsunuz ve farklı karakter sınıfları ile farklı silah türlerini yönetmeniz gerekiyor. Bridge tasarım deseni, bu durumda karakter sınıflarını bir tarafta ve silah türlerini diğer tarafta olmak üzere iki ayrı hiyerarşi olarak ele almanıza yardımcı olabilir. Bu sayede karakter sınıflarını ve silah türlerini bağımsız olarak geliştirebilir ve daha sonra bu iki hiyerarşiyi birleştirerek iletişim kurmalarını sağlayabilirsiniz.

### Kod Örneği

Bridge tasarım desenini daha iyi anlamak için yukarıda bahsettiğimiz senaryoyu kod üzerinde inceleyelim. Öncelikle karakter sınıflarını temsil eden `Character` soyut sınıfını oluşturalım.

```C#
public abstract class Character
{
    protected IWeapon _weapon;

    public Character(IWeapon weapon)
    {
        _weapon = weapon;
    }

    public abstract void Fight();
}
```

`Character` sınıfı, `IWeapon` arayüzünü kullanarak silah türleri ile iletişim kurar. Bu sayede `Character` sınıfı, silah türlerinden bağımsız olarak geliştirilebilir. Şimdi `Character` sınıfından türeyen `Warrior` ve `Archer` sınıflarını oluşturalım.

```C#
public class Warrior : Character
{
    public Warrior(IWeapon weapon) : base(weapon)
    {
    }

    public override void Fight()
    {
        Console.WriteLine("Warrior attacks...");
        _weapon.Hit();
    }
}

public class Archer : Character
{
    public Archer(IWeapon weapon) : base(weapon)
    {
    }

    public override void Fight()
    {
        Console.WriteLine("Archer attacks...");
        _weapon.Hit();
    }
}
```

`Warrior` ve `Archer` sınıfları, `Character` sınıfından türediği için `Fight` metodu üzerinden silah türleri ile iletişim kurabilir. Şimdi silah türlerini temsil eden `IWeapon` arayüzünü oluşturalım.

```C#
public interface IWeapon
{
    void Attack();
}
```

`IWeapon` arayüzü, `Character` sınıfı ile iletişim kurmak için kullanılır. Şimdi `IWeapon` arayüzünden türeyen `Sword` ve `Bow` sınıflarını oluşturalım.

```C#
public class Sword : IWeapon
{
    public void Attack()
    {
        Console.WriteLine("Sword attack...");
    }
}

public class Bow : IWeapon
{
    public void Attack()
    {
        Console.WriteLine("Bow attack...");
    }
}
```

```C#
var warrior = new Warrior(new Sword());
warrior.Fight();

var archer = new Archer(new Bow());
archer.Fight();
```

`Bridge` arayüzü, `Character` ve `IWeapon` hiyerarşilerini birbirine bağlayarak iletişim kurmalarını sağlar. Bu sayede `Character` ve `IWeapon` hiyerarşileri bağımsız olarak geliştirilebilir. Sonuç olarak `Bridge` tasarım deseni, soyutlama ve gerçek uygulamanın ayrılmasını sağlayarak esnek ve modüler bir yapı oluşturmanıza yardımcı olur.

