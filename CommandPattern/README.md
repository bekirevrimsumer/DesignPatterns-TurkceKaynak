## Command Design Pattern
Command tasarım deseni, davranışsal bir tasarım deseni olarak bilinir ve bir işlemi nesne olarak kapsüller. Bu desen, bir eylemi (komutu) içeren bir nesneyi ayırarak, istemcilerin hangi komutların yürütüleceğini dinamik olarak belirlemelerine olanak tanır. Bu şekilde, komutları sırayla işleme koymak, geri almak, sırayla işlemek veya gecikmeli olarak yürütmek gibi işlemleri kolayca gerçekleştirmek mümkün hale gelir.

### Command Pattern'in temel avantajları şunlardır:

- **İşlem Geçmişi ve Geri Alma (Undo/Redo) Desteği**: Command Pattern, her komutun geri alma işlevini içermesini sağlayarak, işlem geçmişini tutma ve geri alma (undo) işlemlerini kolaylaştırır. Bu, uygulamalarda geri alma/ilerleme işlevselliği sağlamak için idealdir.

- **İşlem Kuyruğu ve Sıralama**: Komut nesneleri bir kuyrukta saklanarak belirli bir sırayla işlenebilir. Bu, belirli bir sırayla işlemlerin yürütülmesi gereken senaryolarda kullanışlıdır.

- **İsteklerin Soyutlaması**: İstemciler ve alıcılar arasındaki sıkı bağımlılığı azaltarak, yeni komutları eklemek veya mevcut komutları değiştirmek kolay hale gelir.

- **Paralel İşlemler ve Planlama**: Komutları gecikmeli olarak yürüterek, işlemleri belirli bir zamanda veya belirli koşullar sağlandığında tetikleme yeteneği elde edebilirsiniz.

- **Uzaktan İstekler ve Ağ Operasyonları**: Komut nesneleri, ağ operasyonlarını temsil ederek uzaktan isteklerin işlenmesini kolaylaştırabilir.


### Örnek Senaryo: Hesap Makinesi
Kod örneğimizde Command Pattern kullanılarak bir hesap makinesi senaryosu simüle ediliyor. Her matematiksel işlem (toplama, çıkarma, çarpma, bölme) için bir komut sınıfı oluşturulmuş. Bu komut sınıfları ICommand arayüzünü uyguluyor ve Execute ve Rollback metodlarını içeriyor.

#### Temel Sınıflar
- ICommand: Komut nesnelerinin uygulaması gereken arayüzü tanımlar.
```csharp
public interface ICommand
{
    void Execute(decimal value);
    void Rollback(decimal value);
}
```
- Add, Subtract, Multiply, Divide: Matematiksel işlemleri temsil eden komut sınıfları. Bu sınıflar ICommand arayüzünü uyguluyor ve Execute ve Rollback metodlarını içeriyor.
```csharp
public class AddCommand : ICommand
{
    private readonly double _valueToAdd;
    
    public AddCommand(double valueToAdd)
    {
        _valueToAdd = valueToAdd;
    }

    public double Execute(double currentValue)
    {
        Console.WriteLine($"Adding...: {currentValue}+{_valueToAdd}={currentValue + _valueToAdd}");
        return currentValue += _valueToAdd;
    }

    public double Rollback(double currentValue)
    {
        Console.WriteLine($"Rollbacking...: {currentValue}-{_valueToAdd}={currentValue - _valueToAdd}");
        return currentValue -= _valueToAdd;
    }
}

public class SubtractCommand : ICommand
{
    private readonly double _valueToSubtract;
    
    public SubtractCommand(double valueToSubtract)
    {
        _valueToSubtract = valueToSubtract;
    }

    public double Execute(double currentValue)
    {
        Console.WriteLine($"Subtracting...: {currentValue}-{_valueToSubtract}={currentValue - _valueToSubtract}");
        return currentValue -= _valueToSubtract;
    }

    public double Rollback(double currentValue)
    {
        Console.WriteLine($"Rollbacking...: {currentValue}+{_valueToSubtract}={currentValue + _valueToSubtract}");
        return currentValue += _valueToSubtract;
    }
}

public class MultiplyCommand : ICommand
{
    private readonly double _valueToMultiply;
    
    public MultiplyCommand(double valueToMultiply)
    {
        _valueToMultiply = valueToMultiply;
    }

    public double Execute(double currentValue)
    {
        Console.WriteLine($"Multiplying...: {currentValue}*{_valueToMultiply}={currentValue * _valueToMultiply}");
        return currentValue *= _valueToMultiply;
    }

    public double Rollback(double currentValue)
    {
        Console.WriteLine($"Rollbacking...: {currentValue}/{_valueToMultiply}={currentValue / _valueToMultiply}");
        return currentValue /= _valueToMultiply;
    }
}

public class DivideCommand : ICommand
{
    private readonly double _valueToDivide;
    
    public DivideCommand(double valueToDivide)
    {
        _valueToDivide = valueToDivide;
    }

    public double Execute(double currentValue)
    {
        Console.WriteLine($"Dividing...: {currentValue}/{_valueToDivide}={currentValue / _valueToDivide}");
        return currentValue /= _valueToDivide;
    }

    public double Rollback(double currentValue)
    {
        Console.WriteLine($"Rollbacking...: {currentValue}*{_valueToDivide}={currentValue * _valueToDivide}");
        return currentValue *= _valueToDivide;
    }
}
```
- Calculator: Hesap makinesi sınıfı. Bu sınıf, komut nesnelerini kullanarak işlemleri gerçekleştiriyor ve işlem geçmişini tutuyor.
```csharp
public class Calculator
{
    public double CurrentValue { get; private set; }
    public Stack<ICommand> CommandHistory = new();
    
    public void ExecuteCommand(ICommand command)
    {
        CurrentValue = command.Execute(CurrentValue);
        CommandHistory.Push(command);
    }
    
    public void Rollback()
    {
        if (CommandHistory.Count == 0) return;
        
        var command = CommandHistory.Pop();
        CurrentValue = command.Rollback(CurrentValue);
    }
}
```

### Sonuç
Command tasarım deseni, işlemleri nesnelere dönüştürerek esneklik, geri alma ve işlem geçmişi takibi gibi avantajlar sunar. Bu örnekte, hesap makinesi senaryosunu kullanarak Command Pattern'in nasıl uygulanacağını gördük. Pattern'ın detaylı kullanımı hakkında ayrıntılı bilgiler için [bu rehberi](https://refactoring.guru/design-patterns/command) inceleyebilirsiniz.