using CommandPattern.Interfaces;

namespace CommandPattern.Commands;

public class SubtractCommand : ICommand
{
    private readonly double _valueToSubstract;
    
    public SubtractCommand(double valueToAdd)
    {
        _valueToSubstract = valueToAdd;
    }

    public double Execute(double currentValue)
    {
        Console.WriteLine($"Substracting...: {currentValue}-{_valueToSubstract}={currentValue - _valueToSubstract}");
        return currentValue -= _valueToSubstract;
    }

    public double Rollback(double currentValue)
    {
        Console.WriteLine($"Rollbacking...: {currentValue}+{_valueToSubstract}={currentValue + _valueToSubstract}");
        return currentValue += _valueToSubstract;
    }
}