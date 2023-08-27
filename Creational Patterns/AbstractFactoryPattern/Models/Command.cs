namespace AbstractFactoryPattern.Models;

public abstract class Command
{
    public abstract void ExecuteCommand(string query);
}