using CompositePattern.Interfaces;

namespace CompositePattern.Models;

public class Employee : IEmployee
{
    private string name;
    private string position;

    public Employee(string name, string position)
    {
        this.name = name;
        this.position = position;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Employee: {name}, Position: {position}");
    }

    public string GetNameAndPosition()
    {
        return $"{name} - {position}";
    }
}