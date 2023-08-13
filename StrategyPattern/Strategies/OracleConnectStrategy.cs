using StrategyPattern.Interfaces;

namespace StrategyPattern.Strategies;

public class OracleStrategy : IDatabaseStrategy
{
    public void Connect()
    {
        Console.WriteLine("Connected to Oracle");
    }
    
    public void Query(string query)
    {
        Console.WriteLine($"Query: {query}");
    }
}