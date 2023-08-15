using CommandPattern.Interfaces;

namespace CommandPattern.Models;

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