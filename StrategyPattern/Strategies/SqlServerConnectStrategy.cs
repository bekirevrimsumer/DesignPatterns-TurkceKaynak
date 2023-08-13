using StrategyPattern.Interfaces;

namespace StrategyPattern.Strategies;

public class SqlServerStrategy : IDatabaseStrategy
{
    public void Connect()
    {
        Console.WriteLine("Connected to SQL Server");
    }
    
    public void Query(string query)
    {
        Console.WriteLine($"Query: {query}");
    }
}
