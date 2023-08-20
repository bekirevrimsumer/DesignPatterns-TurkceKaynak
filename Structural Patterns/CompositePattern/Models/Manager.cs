using CompositePattern.Interfaces;

namespace CompositePattern.Models;

public class Manager : IEmployee
{
    private string name;
    private string position;
    private List<IEmployee> subordinates = new List<IEmployee>();

    public Manager(string name, string position)
    {
        this.name = name;
        this.position = position;
    }

    public void AddSubordinate(IEmployee employee)
    {
        subordinates.Add(employee);
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Manager: {name}");
        Console.WriteLine("Subordinates:");
        foreach (var subordinate in subordinates)
        {
            subordinate.DisplayDetails();
        }
    }
    
    public string GetNameAndPosition()
    {
        return $"{name} - {position}";
    }
    
    public List<IEmployee> GetSubordinates()
    {
        return subordinates;
    }
}