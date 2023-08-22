# Flyweight Tasarım Deseni

Flyweight tasarım deseni, bellek kullanımını optimize etmek ve benzer nesneleri paylaşarak sistem performansını artırmak için kullanılan bir tasarım desenidir. Bu desen, aynı veriyi veya nesneyi farklı noktalarda kullanarak gereksiz yinelenen bellek kullanımını önlemeye odaklanır. Flyweight, "hafif ağırlık" anlamına gelir ve desenin temel felsefesi bu kavram üzerine kurulmuştur.

## Neden Kullanırız?

Flyweight deseni, aşağıdaki durumlar gibi birçok senaryoda kullanışlı olabilir:

- **Bellek Tasarrufu**: Büyük miktarda benzer nesnenin oluşturulduğu durumlarda bellek tüketimi hızla artabilir. Flyweight deseni sayesinde aynı nesneler paylaşılır ve bu tüketim azaltılır.

- **Performans İyileştirmesi**: Nesnelerin paylaşılması, nesnelerin oluşturulma ve yok edilme maliyetlerini azaltabilir. Bu, uygulamanın performansını artırabilir.

- **Tekrarlanan Veri Depolama**: Birçok yerde aynı verinin tekrar tekrar depolanmasının önüne geçebiliriz. Bu, veri bütünlüğünü artırır ve gereksiz veri kopyalamasını engeller.

## Örnek Uygulama

Uzun çalışma saatlerinden sonra biraz eğlenmek için basit bir video oyunu yapmaya karar verdiniz: oyuncular bir harita etrafında hareket edecek ve birbirlerini vuracaklar. Oyuna güzel bir particle effect eklemeyi istediniz diyelim. Çok sayıda mermi, füze ve patlamalardan çıkan şarapnel parçaları haritanın her yerinde uçuşmalı ve oyuncuya heyecan verici bir deneyim sunmalıdır.

Şimdi, her biri kendi özelliklerine sahip olan binlerce parçacık oluşturmak istediğinizi düşünün. Bu, bellek tüketimi açısından çok pahalı olabilir. Bunun yerine, her bir parçacık türü için bir Flyweight nesnesi oluşturabilir ve bu nesneleri paylaşabilirsiniz. Bu, bellek tüketimini büyük ölçüde azaltır ve uygulamanın performansını artırır.

### Kod Örneği

Öncelikle ```IParticle``` arayüzünü oluşturuyoruz. Bu arayüz, particle effect'lerin ortak özelliklerini tanımlar. Ayrıca ```Position``` sınıfını oluşturuyoruz. Bu sınıf, particle effect'in konumunu belirtir.

```C#
public interface IParticle
{
    void Draw(Position position);
}

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}
```

Şimdi, ```ParticleType``` sınıfını oluşturuyoruz. Sınıf içerisinde ``type`` adında bir string alanı tanımlıyoruz. Bu alan, particle effect'in türünü belirtir. Ayrıca, ```IParticle``` interface'ini implemente ediyoruz.

```C#
public class ParticleType : IParticle
{
    private string _type;
    
    public ParticleType(string type)
    {
        _type = type;
    }
    
    public void Draw(Position position)
    {
        Console.WriteLine($"Drawing {_type} particle at {position.X}, {position.Y}");
    }
}
```

Şimdi, ```ParticleFactory``` sınıfını oluşturuyoruz. Bu sınıf, ```ParticleType``` sınıflarını oluşturur ve bir dictionary içerisinde saklar. Eğer bir ```ParticleType``` daha önce oluşturulmuşsa, dictionary içerisinden çekilir ve tekrar oluşturulmaz. Bu sayede, aynı ```ParticleType```'dan birden fazla oluşturulmaz ve bellek tüketimi azaltılır.

```C#
public class ParticleFactory
{
    private Dictionary<string, ParticleType> _particleTypes = new Dictionary<string, ParticleType>();
    
    public ParticleType GetParticleType(string type)
    {
        if (!_particleTypes.ContainsKey(type))
        {
            _particleTypes.Add(type, new ParticleType(type));
        }
        
        return _particleTypes[type];
    }
}
```

Son olarak ``GameEngine`` sınıfını oluşturuyoruz. Bu sınıf, ```ParticleFactory``` sınıfını kullanarak ```ParticleType```'ları oluşturur ve kullanır.

```C#
public class GameEngine
{
    private ParticleFactory _particleFactory = new ParticleFactory();
    
    public void Run()
    {
        var player1 = new Player(_particleFactory.GetParticleType("bullet"));
        player1.Shoot(new Position(10, 10));
        player1.Shoot(new Position(100, 100));
        
        var player2 = new Player(_particleFactory.GetParticleType("bullet"));
        player2.Shoot(new Position(20, 20));
        player2.Shoot(new Position(200, 200));
        
        var player3 = new Player(_particleFactory.GetParticleType("laser"));
        player3.Shoot(new Position(30, 30));
        player3.Shoot(new Position(300, 300));
    }
}
```

```GameEngine``` sınıfını çalıştırdığımızda, aşağıdaki çıktıyı alırız:

```OUTPUT
Drawing bullet particle at 10, 10
Drawing bullet particle at 100, 100

Drawing bullet particle at 20, 20
Drawing bullet particle at 200, 200

Drawing laser particle at 30, 30
Drawing laser particle at 300, 300
```

Bu örnekte de gördüğümüz gibi, Flyweight deseni bellek tüketimini azaltmak ve performansı artırmak için kullanılabilir. Bu desen, birçok yerde kullanılabilir ve uygulamaların performansını artırabilir.


