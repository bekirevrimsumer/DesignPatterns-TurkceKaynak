using CommandPattern.Interfaces;

namespace CommandPattern.Commands;

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