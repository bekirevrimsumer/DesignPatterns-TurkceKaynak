
using MementoPattern.Models;

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
