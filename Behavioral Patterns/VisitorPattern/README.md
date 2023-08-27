# Visitor Design Pattern

Visitor Design Pattern, nesne yapısını dolaşmak ve farklı işlemleri nesneler üzerinde gerçekleştirmek için kullanılan bir tasarım desenidir. Bu desen, özellikle nesne yapısı değiştiğinde veya yeni işlemler eklenmesi gerektiğinde kodun esnekliğini ve sürdürülebilirliğini artırır.

## Neden Visitor Design Pattern?
Bir uygulamada nesnelerin yapısı ve davranışları sürekli olarak değişebilir. Bu durumda, her nesne türü için farklı işlemler eklemek veya mevcut işlemleri değiştirmek zor olabilir. Visitor Design Pattern bu soruna çözüm sunar. Bu desen, her bir işlemi ayrı bir sınıfa kapsüller ve nesneleri ziyaretçilere (Visitor) kabul ettirir. Böylece yeni işlemler eklemek veya nesnelerin yapısını değiştirmek, var olan kodu değiştirmeden yapılabilir.

## Avantajlar
- **Esneklik**: Yeni işlemler eklemek veya nesne yapısını değiştirmek için mevcut kodu değiştirmek gerekmez.
- **Ayırma**: İşlemler, nesnelerin sınıflarından ayrılır ve ayrı sınıflar olarak tutulur.
- **Tek Yerden Kontrol**: Benzer işlemleri tek bir yerde yönetmek ve güncellemek kolaylaşır.
- **Kod Temizliği**: İşlemler, ilgili nesnelerin sınıflarından ayrıldığı için kod daha temiz ve sade olur.

## Örnek Senaryo
Bu senaryoda, belge işleme uygulaması üzerinde çalışıyorsunuz. Farklı türde belgeler var (Word, PDF) ve her belge türüne özgü işlemler yapmanız gerekiyor. Örneğin, Word belgelerindeki metinleri PDF belgelerine dönüştürmek ve PDF dosylarını da sıkıştırmak istiyorsunuz. Bu işlemleri yapmak için her belge türü için ayrı sınıflar oluşturabilirsiniz. Ancak bu durumda, yeni bir belge türü eklemek istediğinizde, her bir işlem için yeni sınıflar oluşturmanız gerekir. Ayrıca, her belge türü için ayrı sınıflar oluşturmak, kodun karmaşıklaşmasına ve bakımının zorlaşmasına neden olur.

## Örnek Kod

Öncelikle interface'lerimizi oluşturalım. İlk olarak belge türlerimizi temsil eden `IDocument` interface'ini oluşturalım.

```C#
public interface IDocument
{
    void Accept(IDocumentVisitor visitor);
}
```

Sonrasında `IDocumentVisitor` interface'ini oluşturalım. Bu interface, belge türlerine özgü işlemleri tanımlar. Bu interface'yi uygulayan sınıflar, belge türlerine özgü işlemleri gerçekleştirir.

```C#
public interface IDocumentVisitor
{
    void Visit(WordDocument doc);
    void Visit(PdfDocument doc);
}
```

Şimdi belge türlerimizi temsil eden sınıfları oluşturalım. İlk olarak `WordDocument` sınıfını oluşturalım.

```C#
public class WordDocument : IDocument
{
    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
    
    public void ConvertToPdf()
    {
        Console.WriteLine("Converting Word document to PDF...");
        Export();
    }
    
    private void Export()
    {
        Console.WriteLine("Exporting Word document...");
    }
}
```

Sonrasında `PdfDocument` sınıfını oluşturalım.

```C#
public class PdfDocument : IDocument
{
    public void Accept(IDocumentVisitor visitor)
    {
        visitor.Visit(this);
    }
    
    public void Compress()
    {
        Console.WriteLine("Compressing PDF document...");
    }
    
    public void Export()
    {
        Console.WriteLine("Exporting PDF document...");
    }
}
```

Şimdi belge türlerine özgü işlemleri gerçekleştiren sınıfları oluşturalım. İlk olarak `ExportVisitor` sınıfını oluşturalım.

```C#
public class ExportVisitor : IDocumentVisitor
{
    public void Visit(WordDocument doc)
    {
        doc.ConvertToPdf();
    }

    public void Visit(PdfDocument doc)
    {
        Console.WriteLine("Exporting PDF document...");
    }
}
```

Sonrasında `CompressionVisitor` sınıfını oluşturalım.

```C#
public class CompressionVisitor : IDocumentVisitor
{
    public void Visit(WordDocument doc)
    {
        Console.WriteLine("No compression for Word documents.");
    }

    public void Visit(PdfDocument doc)
    {
        doc.Compress();
    }
}
```

Son olarak ``DocumentProcessor`` sınıfını oluşturalım.

```C#
public class DocumentProcessor
{
    private List<IDocument> _documents = new();
    
    public void AddDocument(IDocument document)
    {
        _documents.Add(document);
    }
    
    public void Process(IDocumentVisitor visitor)
    {
        foreach (var document in _documents)
        {
            document.Accept(visitor);
        }
    }
}
```

Bu sınıf, belge türlerini tutan bir listeye sahiptir. `AddDocument()` metodu ile bu listeye belge türlerini ekleyebiliriz. `Process()` metodu ile de belge türlerine özgü işlemleri gerçekleştirebiliriz.

Şimdi oluşturduğumuz sınıfları kullanalım.

```C#
var documentProcessor = new DocumentProcessor();
documentProcessor.AddDocument(new WordDocument());
documentProcessor.AddDocument(new PdfDocument());

var exportVisitor = new ExportVisitor();
var compressionVisitor = new CompressionVisitor();

Console.WriteLine("Exporting documents:");
documentProcessor.Process(exportVisitor);

Console.WriteLine("\nCompressing documents:");
documentProcessor.Process(compressionVisitor);
```

Çıktı:

```
Exporting documents:
Converting Word document to PDF...
Exporting Word document...
Exporting PDF document...

Compressing documents:
No compression for Word documents.
Compressing PDF document...
```

Sonuç olarak, `DocumentProcessor` sınıfı, belge türlerini tutan bir listeye sahiptir. Bu sınıf, belge türlerine özgü işlemleri gerçekleştirmek için `IDocumentVisitor` interface'ini kullanır. `IDocumentVisitor` interface'ini uygulayan sınıflar, belge türlerine özgü işlemleri gerçekleştirir. Bu sayede, yeni bir belge türü eklemek istediğimizde, sadece `IDocument` interface'ini uygulayan bir sınıf oluşturmamız yeterlidir. Ayrıca, `DocumentProcessor` sınıfı, belge türlerine özgü işlemleri gerçekleştirmek için `IDocumentVisitor` interface'ini kullanır. Bu sayede, `DocumentProcessor` sınıfı, belge türlerine özgü işlemleri gerçekleştiren sınıfların türlerini bilmez. Bu sayede, `DocumentProcessor` sınıfı, belge türlerine özgü işlemleri gerçekleştiren sınıfların türlerini bilmediği için, bu sınıfların türlerinde bir değişiklik olduğunda etkilenmez.
