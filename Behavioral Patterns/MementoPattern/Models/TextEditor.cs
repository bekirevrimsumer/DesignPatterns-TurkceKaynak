namespace MementoPattern.Models;

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