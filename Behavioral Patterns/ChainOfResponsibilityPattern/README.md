# Chain of Responsibility Design Pattern

Chain of Responsibility Design Pattern, nesnelerin bir zincir halinde bağlanarak isteklerin sırayla işlendiği bir davranışsal desendir. Bu desen, bir isteğin hangi nesne tarafından işleneceğini belirlemek için hiyerarşik bir yapı kullanır ve isteği işlemek için bir nesnenin başarısız olması durumunda bir sonraki nesneye iletilmesine dayanır. Bu şekilde, isteğin işlenme süreci, zincirdeki her bir nesnenin sorumluluklarını taşıdığı bir modelde gerçekleşir.

## Nerelerde Kullanılır?

Chain of Responsibility Design Pattern, aşağıdaki durumlarda kullanışlıdır:

- **Birden Fazla Nesne İşlem Yapmalı**: Bir isteğin işlenmesi için birden fazla nesnenin sırayla denemesi gerektiği durumlarda kullanılabilir. Örneğin, farklı validasyon kuralları veya onay süreçleri gibi.

- **Kodun Modüler Olması Gerekiyor**: Zincirdeki her bir nesne, tek bir sorumluluğu taşır. Bu, kodun daha modüler ve sürdürülebilir olmasını sağlar.

- **Kodun Esnek Olması Gerekiyor**: Zincire yeni nesneler eklemek veya mevcut nesneleri çıkarmak, sistemin davranışını değiştirmek için kolaylıkla yapılabilir.

Şu sorunlara çözüm sunar:

- **Bağlantısızlık (Loose Coupling)**: İstek gönderen ve isteği işleyen nesneler arasındaki sıkı bağımlılığı azaltır. İstek gönderen, hangi nesnenin isteği işleyeceğini bilmez.

- **Sorumlulukların Dağıtımı**: Her nesne sadece kendi sorumluluğuyla ilgilenir ve işlemi sırayla zincirdeki diğer nesnelere iletir.

- **Esneklik ve Genişletilebilirlik**: Yeni nesneleri zincire eklemek veya mevcut nesneleri değiştirmek, sistemin davranışını esnek bir şekilde genişletmeye ve değiştirmeye olanak tanır.

Şu kolaylıkları sağlar:

- **Kod Tekrarını Azaltır**: Benzer işlemleri yapan nesneleri tekrar kullanmak yerine zincirde paylaşabilirsiniz.

- **Kodun Anlaşılabilirliği**: Her nesne sadece kendi sorumluluğunu taşıdığı için kod daha anlaşılır ve bakımı daha kolay hale gelir.

- **Dinamik Davranış Değişiklikleri**: Zincire yeni nesneler eklemek veya çıkarmak, sistemin davranışını dinamik olarak değiştirmenizi sağlar.

## Kod Örneği: Validasyon Zinciri

### Kötü Tasarım

Aşağıdaki kod örneğinde, isteğin geçerli olup olmadığını kontrol eden bir zincir oluşturacağız. Zincirdeki her bir nesne, isteğin geçerli olup olmadığını kontrol eden bir kuralı uygular. Zincirdeki her bir nesne, isteğin geçerli olup olmadığını kontrol eden bir kuralı uygular. Zincirdeki her bir nesne, isteğin geçerli olup olmadığını kontrol eden bir kuralı uygular.

```csharp
public class BadValidationExample
{
    public static bool ValidateName(RequestModel request)
    {
        if (request.Name.Length < 6)
        {
            Console.WriteLine("Name must be at least 6 characters long.");
            return false;
        }
        return true;
    }

    public static bool ValidateDigits(RequestModel request)
    {
        if (request.Name.Any(char.IsDigit))
        {
            Console.WriteLine("Name must not contain digits.");
            return false;
        }
        return true;
    }

    public static bool ValidateUpperCase(RequestModel request)
    {
        if (request.Name.Any(char.IsUpper))
        {
            Console.WriteLine("Name must not contain upper case characters.");
            return false;
        }
        return true;
    }

    public static void Main(string[] args)
    {
        var requestModel = new RequestModel() { Name = "john wick" };

        bool isValid = ValidateName(requestModel);
        if (isValid)
        {
            isValid = ValidateDigits(requestModel);
            if (isValid)
            {
                isValid = ValidateUpperCase(requestModel);
                if (isValid)
                {
                    Console.WriteLine("Validation succeeded.");
                }
                else
                {
                    Console.WriteLine("Validation failed.");
                }
            }
            else
            {
                Console.WriteLine("Validation failed.");
            }
        }
        else
        {
            Console.WriteLine("Validation failed.");
        }
    }
}
```

Görüldüğü üzere kod tekrarı mevcut ve kodun okunabilirliği düşük. Ayrıca yeni bir kural eklemek istediğimizde mevcut kodu değiştirmemiz gerekiyor.

### İyi Tasarım

- IRule Arayüzü: Validasyon kurallarının uygulanması için temel arayüzü tanımlar.

```csharp
public interface IRule
{
    IRule NextRule { get; set; }
    bool Validate(RequestModel request);
}
```

- Rule Sınıfı: IRule arayüzünün temel uygulamasını içerir ve zincirdeki bir sonraki kuralı yönlendirmek için bir NextRule özelliği bulunur.

```csharp
public class Rule
{
    public IRule NextRule { get; set; }
}
```

- RequestModel Sınıfı: Adı temsil eden bir sınıf.

```csharp
public class RequestModel
{
    public string Name { get; set; }
}
```

- MinLengthValidationRule: En az belirtilen uzunlukta olup olmadığını kontrol eden bir kuralları uygular. Ayrıca zincirdeki bir sonraki kuralı tanımlar.

```csharp
public class MinLengthValidationRule : Rule, IRule
{
    private readonly int _minLength;

    public MinLengthValidationRule(int minLength)
    {
        _minLength = minLength;
    }

    public bool Validate(RequestModel request)
    {
        if (request.Name.Length < _minLength)
        {
            return false;
        }

        if (NextRule != null)
        {
            return NextRule.Validate(request);
        }

        return true;
    }
}
```
- NoDigitsValidationRule: Rakam içermemesi gerektiğini kontrol eden bir kuralı uygular. Zincirdeki bir sonraki kuralı da belirler.

```csharp
public class NoDigitsValidationRule : Rule, IRule
{
    public NoDigitsValidationRule()
    {
        NextRule = new NoUpperCaseValidationRule();
    }
    
    public bool Handle(RequestModel request)
    {
        if (request.Name.Any(char.IsDigit))
        {
            Console.WriteLine("Name must not contain digits.");
            return false;
        }

        if (NextRule != null)
        {
            return NextRule.Handle(request);
        }

        return true;
    }
}
```
- NoUpperCaseValidationRule: Büyük harf içermemesi gerektiğini kontrol eden bir kuralı uygular. Zincirde bir sonraki kuralın olmadığını belirtir.

```csharp
public class NoUpperCaseValidationRule : Rule, IRule
{
    public NoUpperCaseValidationRule()
    {
        NextRule = null;
    }
    
    public bool Handle(RequestModel request)
    {
        if (request.Name.Any(char.IsUpper))
        {
            Console.WriteLine("Name must not contain upper case characters.");
            return false;
        }

        if (NextRule != null)
        {
            return NextRule.Handle(request);
        }

        return true;
    }
}
```
Burada önemli bir nokta, son validasyonun constructor'ında zincirdeki bir sonraki kuralı null olarak belirtmemizdir. Bu, zincirin sonuna geldiğimizi belirtir.

Program Sınıfı: Örneği oluşturan ve zinciri çalıştıran ana programı içerir. Bir adın geçerliliğini zincir boyunca kontrol eder ve sonucu yazdırır.

```csharp
var requestModel = new RequestModel() { Name = "john wick" };

IRule rule = new MinLengthValidationRule(6);
while (rule.NextRule != null)
{
    if (rule.Handle(requestModel))
    {
        rule = rule.NextRule;
    }
    else
    {
        Console.WriteLine("Validation failed.");
        break;
    }
}

if (rule.NextRule == null)
{
    if (rule.Handle(requestModel))
    {
        Console.WriteLine("Validation succeeded.");
    }
    else
    {
        Console.WriteLine("Validation failed.");
    }
}
```
Öncelikle While döngüsü ile NextRule null olana kadar zincirdeki kuralları dolaşırız. Döngüden çıktıktan sonra zincirin sonuna geldiğimizi anlarız. Son kuralı kontrol ederiz. Eğer başarılı olursa "Validation succeeded.", başarısız olursa "Validation failed." yazdırarak validasyon işlemlerini sonlandırmış oluruz.