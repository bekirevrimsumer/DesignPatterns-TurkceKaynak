namespace AbstractFactoryPattern.Models;

public abstract class Connection
{ 
    public abstract bool Connect();
    public abstract bool Disconnect();
}