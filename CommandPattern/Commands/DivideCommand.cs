using CommandPattern.Interfaces;

namespace CommandPattern.Commands;

public class DivideCommand : ICommand
{
    private readonly double _valueToDivide;
    
    public DivideCommand(double valueToDivide)
    {
        _valueToDivide = valueToDivide;
    }

    public double Execute(double currentValue)
    {
        Console.WriteLine($"Dividing...: {currentValue}/{_valueToDivide}={currentValue / _valueToDivide}");
        return currentValue /= _valueToDivide;
    }

    public double Rollback(double currentValue)
    {
        Console.WriteLine($"Rollbacking...: {currentValue}*{_valueToDivide}={currentValue * _valueToDivide}");
        return currentValue *= _valueToDivide;
    }
}