namespace MementoPattern.Models;

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