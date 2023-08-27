namespace AbstractFactoryPattern.Models;

public class MySqlConnection : Connection
{
    public override bool Connect()
    {
        Console.WriteLine("Connecting to MySQL database...");
        return true;
    }

    public override bool Disconnect()
    {
        Console.WriteLine("Disconnecting from MySQL database...");
        return true;
    }
}