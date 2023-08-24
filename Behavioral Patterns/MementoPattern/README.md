# Memento Tasarım Deseni
Memento tasarım deseni, bir nesnenin iç durumunun (state) anlık olarak kaydedilip daha sonra geri yüklenebilmesini sağlayan bir tasarım desenidir. Bu desen, bir nesnenin geçmiş durumlarına geri dönmek veya gelecekteki durumlarına ilerlemek gibi işlemleri yapmak için kullanılır. Temel olarak, bir nesnenin anlık görüntüsünü (snapshot) yakalamak ve ileride bu görüntüyü kullanmak amacıyla kullanılır.

## Ne İşimize Yarar?
Bir yazılım uygulamasında, kullanıcının yaptığı işlemleri geri almak veya ileri almak gerekebilir. Aynı zamanda, bir nesnenin geçmiş durumlarına geri dönerek hataları düzeltmek veya farklı senaryoları test etmek isteyebiliriz. Memento tasarım deseni bu tür durumları ele alır ve nesnelerin iç durumlarını yönetmek ve korumak için kullanılır.

## Avantajları
- **Geçmiş durumları yönetir**: Nesnenin geçmiş durumlarını kaydederek ve yöneterek, geri al ve ileri al gibi işlemleri kolaylaştırır.


- **Kapsülleme sağlar**: Nesnenin iç durumunu dışarıya karşı gizler ve yalnızca Memento nesneleri aracılığıyla bu durumun erişilmesini sağlar.


- **Durumun dışarıya açılmasını engeller**: Memento, Originator nesnenin iç durumunu sadece kendisi kullanabilir ve dışarıya karşı gizler, bu da daha iyi bir sarmalama (encapsulation) sağlar.


- **Çoklu geri alma işlemleri**: Çoklu geri alma işlemleri, kullanıcıya birden fazla geri alma adımı sunarak daha esnek bir deneyim sağlar.

## Örnek Senaryo

Bir metin düzenleyici uygulaması düşünün. Kullanıcı metin yazarken, geri al ve ileri al gibi işlemleri yapabilmek istiyor. Memento tasarım deseni, bu durumu gerçekleştirmek için kullanılabilir.

### Örnek Kod

Öncelikle, `TextEditor` sınıfını oluşturuyoruz. Bu sınıf, kullanıcının metin girdiği ve geri alma işlemlerini yaptığı sınıftır.

```C#
public class TextEditor
{
    private string _text;
    
    public TextEditor(string text)
    {
        _text = text;
    }
    
    public void WriteText(string text)
    {
        _text += text;
    }
    
    public string GetText()
    {
        return _text;
    }
    
    public TextEditorMemento CreateMemento()
    {
        return new TextEditorMemento(_text);
    }
    
    public void Restore(TextEditorMemento memento)
    {
        _text = memento.GetSavedText();
    }
}
```

`TextEditor` sınıfı, `TextEditorMemento` sınıfını kullanarak geçmiş durumlarını yönetir. `TextEditorMemento` sınıfı, `TextEditor` sınıfının geçmiş durumlarını tutar.

```C#
public class TextEditorMemento
{
    private string _text;
    
    public TextEditorMemento(string text)
    {
        _text = text;
    }
    
    public string GetSavedText()
    {
        return _text;
    }
}
```

Son olarak, `TextHistory` sınıfını oluşturuyoruz. Bu sınıf, `TextEditor` sınıfının geçmiş durumlarını yönetir.

```C#
public class TextHistory
{
    private TextEditorMemento[] _history = new TextEditorMemento[10];
    private int _currentIndex = -1;
    
    public void SaveMemento(TextEditorMemento memento)
    {
        _currentIndex++;
        _history[_currentIndex] = memento;
    }

    public TextEditorMemento Undo()
    {
        if(_currentIndex < 0) return null;
        _currentIndex--;
        return _history[_currentIndex];
    }
    
    public TextEditorMemento Redo()
    {
        if(_currentIndex > _history.Length) return null;
        _currentIndex++;
        return _history[_currentIndex];
    }
}
```

Bu sınıfta geçmişi tutmanın farklı yolları olabilir. Ben örneğimde `TextEditorMemento[]` dizisini kullandım. Farklı senaryolara göre burada stack, list veya queue gibi farklı veri yapıları da kullanılabilir.

### Örnek Kullanım

```C#

var textEditor = new TextEditor("");
var textHistory = new TextHistory();

textEditor.WriteText("Hello");
textHistory.SaveMemento(textEditor.CreateMemento());

textEditor.WriteText(" World");
textHistory.SaveMemento(textEditor.CreateMemento());

textEditor.WriteText("!");
textHistory.SaveMemento(textEditor.CreateMemento());

Console.WriteLine(textEditor.GetText());

textEditor.Restore(textHistory.Undo());
Console.WriteLine(textEditor.GetText());

textEditor.Restore(textHistory.Undo());
Console.WriteLine(textEditor.GetText());

textEditor.Restore(textHistory.Redo());
Console.WriteLine(textEditor.GetText());

textEditor.Restore(textHistory.Redo());
Console.WriteLine(textEditor.GetText());
```

### Örnek Çıktı

```
Hello World!
Hello World
Hello
Hello World
Hello World!
```

