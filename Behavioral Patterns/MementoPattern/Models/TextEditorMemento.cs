namespace MementoPattern.Models;

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