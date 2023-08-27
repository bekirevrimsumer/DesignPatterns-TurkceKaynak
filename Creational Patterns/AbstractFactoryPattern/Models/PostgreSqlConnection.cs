namespace AbstractFactoryPattern.Models;

public class PostgreSqlConnection : Connection
{
    public override bool Connect()
    {
        Console.WriteLine("Connecting to PostgreSql database...");
        return true;
    }

    public override bool Disconnect()
    {
        Console.WriteLine("Disconnecting from PostgreSql database...");
        return true;
    }
}