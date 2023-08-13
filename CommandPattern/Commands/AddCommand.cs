using CommandPattern.Interfaces;

namespace CommandPattern.Commands;

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