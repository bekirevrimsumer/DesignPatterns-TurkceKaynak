# Iterator Tasarım Deseni

Iterator tasarım deseni, bir koleksiyon yapısının içindeki elemanlara sırayla erişim sağlamak amacıyla kullanılan bir davranışsal tasarım desenidir. Bu desen, koleksiyonun yapısını ve elemanlarının depolanma şeklini gizlerken, elemanlara erişim mekanizmasını standartlaştırır. Bu sayede koleksiyon üzerinde dolaşma işlemi daha esnek ve daha düzenli bir şekilde yapılabilir.

## Neden Kullanırız?

Iterator tasarım deseni, aşağıdaki durumlarda kullanışlı olabilir:

- **Farklı Erişim Yolları**: Koleksiyonun elemanlarına farklı erişim yolları sağlamak istediğimizde Iterator deseni kullanabiliriz. Bu, koleksiyonun iç yapısını dışarıya yansıtmadan farklı erişim şekilleri sunmamızı sağlar.

- **Koleksiyonun Detaylarını Gizleme**: Koleksiyonun iç yapısını gizleyerek erişimi standartlaştırırız. Bu, koleksiyonun iç yapısının değişmesi durumunda dışarıya etki etmeyi önler.

## Örnek Senaryo

Bir şirkette çalışanların listesini tutan bir koleksiyonumuz olduğunu düşünelim. Bu koleksiyon, çalışanların isimlerini ve departman bilgilerini tutuyor olsun. Bu koleksiyon üzerinde dolaşmak için Iterator tasarım desenini kullanabiliriz. Bu sayede koleksiyonun iç yapısını dışarıya yansıtmadan, koleksiyon üzerinde dolaşma işlemini standartlaştırabiliriz.

### Örnek Kod

Iterator tasarım desenini kullanarak, bir koleksiyon üzerinde dolaşmak için aşağıdaki adımları izleyebiliriz:

- **``IIterator`` Interface'ini Oluşturma**: Iterator interface'i, koleksiyon üzerinde dolaşmak için gerekli olan metotları tanımlar. Bu metotlar, koleksiyonun iç yapısını dışarıya yansıtmadan koleksiyon üzerinde dolaşmamızı sağlar.

```C#
public interface IIterator
{
    bool HasNext();
    void Next();
}
```

- **``IAggregate`` Interface'ini Oluşturma**: Aggregate interface'i, koleksiyonun iç yapısını dışarıya yansıtmadan koleksiyon üzerinde dolaşmamızı sağlayan Iterator nesnesini oluşturur.

```C#
public interface IAggregate
{
    IIterator GetIterator();
}
```

- **``Employee`` Sınıfını Oluşturma**: Employee sınıfı, koleksiyonun elemanlarını temsil eder.

```C#
public class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    
    public Employee(string name, string department)
    {
        Name = name;
        Department = department;
    }
}
```

- **``EmployeeAggregate`` Sınıfını Oluşturma**: EmployeeAggregate sınıfı, koleksiyonun iç yapısını ve koleksiyon üzerinde dolaşmak için gerekli olan metotları içerir.

```C#
public class EmployeeAggregate : IAggregate
{
    List<Employee> _employees = new List<Employee>();
    
    public void Add(Employee employee)
    {
        _employees.Add(employee);
    }
    
    public Employee Get(int index)
    {
        return _employees[index];
    }
    
    public int Count()
    {
        return _employees.Count;
    }
    
    public IIterator CreateIterator()
    {
        return new EmployeeIterator(this);
    }
}
```

- **``EmployeeIterator`` Sınıfını Oluşturma**: EmployeeIterator sınıfı, koleksiyon üzerinde dolaşmak için gerekli olan metotları içerir.

```C#
public class EmployeeIterator : IIterator
{
    private EmployeeAggregate _aggregate;
    private int _index = 0;
    
    public EmployeeIterator(EmployeeAggregate aggregate)
    {
        _aggregate = aggregate;
    }
    
    public bool HasNext()
    {
        return _index < _aggregate.Count();
    }

    public Employee Next()
    {
        return _aggregate.Get(_index++);
    }
}
```

- **Kullanım**

```C#
var employeeAggregate = new EmployeeAggregate();
employeeAggregate.Add(new Employee(){ Name = "John", Surname = "Doe", Department = "IT", Title = "Software Developer" });
employeeAggregate.Add(new Employee(){ Name = "Jane", Surname = "Doe", Department = "Marketing", Title = "Marketing Manager" });
employeeAggregate.Add(new Employee(){ Name = "Jack", Surname = "Doe", Department = "IT", Title = "Software Developer" });


var employeeIterator = employeeAggregate.CreateIterator();

while (employeeIterator.HasNext())
{
    var employee = employeeIterator.Next();
    Console.WriteLine($"{employee.Name} {employee.Surname} - {employee.Department} - {employee.Title}");
}
```

Bu örnek senaryoda da görüldüğü gibi, Iterator tasarım deseni sayesinde koleksiyon üzerinde dolaşma işlemini standartlaştırabildik. Bu sayede koleksiyonun iç yapısını dışarıya yansıtmadan, koleksiyon üzerinde dolaşma işlemini gerçekleştirebildik.