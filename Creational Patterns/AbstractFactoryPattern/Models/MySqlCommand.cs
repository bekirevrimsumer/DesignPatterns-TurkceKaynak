namespace AbstractFactoryPattern.Models;

public class MySqlCommand : Command
{
    public override void ExecuteCommand(string query)
    {
        Console.WriteLine($"Executing query: {query}");
    }
}