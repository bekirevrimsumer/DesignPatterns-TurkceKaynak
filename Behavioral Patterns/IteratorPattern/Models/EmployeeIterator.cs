using IteratorPattern.Interfaces;

namespace IteratorPattern.Models;

public class EmployeeIterator : IIterator
{
    private EmployeeAggregate _aggregate;
    private int _index = 0;
    
    public EmployeeIterator(EmployeeAggregate aggregate)
    {
        _aggregate = aggregate;
    }
    
    public bool HasNext()
    {
        return _index < _aggregate.Count();
    }

    public Employee Next()
    {
        return _aggregate.Get(_index++);
    }
}