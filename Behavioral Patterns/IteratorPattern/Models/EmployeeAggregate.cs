using IteratorPattern.Interfaces;

namespace IteratorPattern.Models;

public class EmployeeAggregate : IAggregate
{
    List<Employee> _employees = new List<Employee>();
    
    public void Add(Employee employee)
    {
        _employees.Add(employee);
    }
    
    public Employee Get(int index)
    {
        return _employees[index];
    }
    
    public int Count()
    {
        return _employees.Count;
    }
    
    public IIterator CreateIterator()
    {
        return new EmployeeIterator(this);
    }
}