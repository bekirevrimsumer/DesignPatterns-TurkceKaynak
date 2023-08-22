# Composite Tasarım Deseni
Composite Design Pattern, nesneleri hiyerarşik bir yapıda düzenlemek için kullanılan bir yapısal tasarım desenidir. Bu desen, bütün ve parça ilişkilerini modellemek amacıyla kullanılır. Yani, bir nesnenin alt nesneleri olabilir ve bu alt nesneler de alt nesneleri içerebilir. Bu hiyerarşik yapının her düzeyde aynı arayüzü uygulayan bileşenler veya bileşik nesneler tarafından temsil edilmesi sağlanır. Bu desen, karmaşık nesne yapısını yönetmeyi ve işlemeyi kolaylaştırır.

## Nerede Kullanılır?
- **Ağaç Yapıları**: Nesnelerin bir ağaç yapısı oluşturduğu senaryolarda kullanılır. Örneğin, dosya sistemi, organizasyon hiyerarşileri gibi yapılarda Composite tasarım deseni kullanılabilir.


- **Parça-Bütün İlişkileri**: Bir nesnenin parça-bütün ilişkilerini temsil etmek istediğinizde kullanışlıdır. Örneğin, bir evin odaları, odaların mobilyaları gibi durumlar için bu deseni kullanabilirsiniz.


- **Kullanıcı Arayüzleri**: Grafiksel kullanıcı arayüzlerinde, bileşenler ve bileşen grupları (paneller, menüler) arasındaki ilişkiyi modellemek için kullanılabilir.


- **Veri Yapıları**: Veri yapıları, birbiri içinde bulunan veri öğeleri veya nesneleri temsil ederken Composite desenini kullanabilir.

## Ne İşe Yarar?
- **Nesne Yapılarını Basitleştirir**: Composite deseni, alt bileşenler ve bileşik nesneler arasındaki farkı gizler. Bu sayede karmaşık yapılarda bileşenleri tek bir arayüzle yönetmek ve işlemek kolaylaşır.


- **Hiyerarşik İşlemler**: İşlemler, bileşik nesnelerin alt nesnelerine rekürsif olarak uygulanabilir. Bu sayede hiyerarşik işlemler kolayca gerçekleştirilebilir.


- **Esneklik ve Genişletilebilirlik**: Yeni bileşenler eklemek veya varolanları değiştirmek Composite deseni ile kolaydır. Bu sayede sistemi esnek ve genişletilebilir hale getirebilirsiniz.

## Kod Örneği

### Senaryo

Bir organizasyon içinde çalışanları ve yöneticileri temsil eden bir yapı oluşturulması hedeflenmiştir. Çalışanlar (Employee) ve yöneticiler (Manager) birbiri içinde bulunan bir yapıda gruplanarak hiyerarşik bir organizasyon yapısı oluşturulmuştur.

### Kod Örneği

Manager sınıfı, Subordinates isimli bir liste içerir. Bu liste, her bir manager'ın altında çalışan employee'ları temsil eder. AddSubordinate metodu, bir çalışanı manager'ın altına eklemek için kullanılır. Employee sınıfının altında çalışan bir çalışan olamayacağı için Subordinates listesi bu sınıfta bulunmaz.

```C#
public interface IEmployee
{
    void DisplayDetails();
    string GetNameAndPosition();
}

public class Employee : IEmployee
{
    public string Name { get; set; }
    public string Position { get; set; }

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void DisplayDetails()
    {
        Console.WriteLine(GetNameAndPosition());
    }

    public string GetNameAndPosition()
    {
        return $"{Name} - {Position}";
    }
}

public class Manager : IEmployee
{
    public string Name { get; set; }
    public string Position { get; set; }
    public List<IEmployee> Subordinates { get; set; }

    public Manager(string name, string position)
    {
        Name = name;
        Position = position;
        Subordinates = new List<IEmployee>();
    }

    public void DisplayDetails()
    {
        Console.WriteLine(GetNameAndPosition());
        Console.WriteLine("Subordinates:");
        foreach (var subordinate in Subordinates)
        {
            subordinate.DisplayDetails();
        }
    }

    public string GetNameAndPosition()
    {
        return $"{Name} - {Position}";
    }
}
```

DisplayTree metodu, bir çalışanın altındaki çalışanları tree yapısında ekrana yazdırmak için kullanılır.

```C#
var ceo = new Manager("John", "CEO");

var hrManager = new Manager("Anna", "HR Manager");
hrManager.AddSubordinate(new Employee("Emma", "HR Specialist"));
hrManager.AddSubordinate(new Employee("Mike", "HR Coordinator"));

var itManager = new Manager("Mark", "IT Manager");
itManager.AddSubordinate(new Employee("Alex", "Software Developer"));
itManager.AddSubordinate(new Employee("Laura", "QA Engineer"));

ceo.AddSubordinate(hrManager);
ceo.AddSubordinate(itManager);

DisplayTree(ceo, 0);

static void DisplayTree(IEmployee employee, int depth)
{
    string indentation = new string('-', depth);
    Console.WriteLine($"{indentation}{employee.GetType().Name}: {employee.GetNameAndPosition()}");

    if (employee is Manager manager)
    {
        foreach (var subordinate in manager.GetSubordinates())
        {
            DisplayTree(subordinate, depth + 1);
        }
    }
}

// ----- OUTPUT -----
// Manager: John - CEO
// -Manager: Anna - HR Manager
// --Employee: Emma - HR Specialist
// --Employee: Mike - HR Coordinator
// -Manager: Mark - IT Manager
// --Employee: Alex - Software Developer
// --Employee: Laura - QA Engineer
```

Sonuç olarak, Composite tasarım deseni, nesneleri hiyerarşik bir yapıda düzenlemek için kullanılır. Bu desen, bütün ve parça ilişkilerini modellemek amacıyla kullanılır. Yani, bir nesnenin alt nesneleri olabilir ve bu alt nesneler de alt nesneleri içerebilir. Bu hiyerarşik yapının her düzeyde aynı arayüzü uygulayan bileşenler veya bileşik nesneler tarafından temsil edilmesi sağlanır. Bu desen, karmaşık nesne yapısını yönetmeyi ve işlemeyi kolaylaştırır.
