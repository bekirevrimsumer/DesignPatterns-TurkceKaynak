namespace AdapterPattern.Databases;

public class NoSqlDatabase
{
    public void Find(string query)
    {
        Console.WriteLine($"Executing NoSQL query: {query}");
    }
}