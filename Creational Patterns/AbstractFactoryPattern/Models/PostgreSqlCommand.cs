namespace AbstractFactoryPattern.Models;

public class PostgreSqlCommand : Command
{
    public override void ExecuteCommand(string query)
    {
        Console.WriteLine($"Executing query: {query}");
    }
}