namespace AdapterPattern.Databases;

public class SqlDatabase
{
    public void Query(string sqlQuery)
    {
        Console.WriteLine($"Executing SQL query: {sqlQuery}");
    }
}