using AbstractFactoryPattern.Models;

namespace AbstractFactoryPattern.Interfaces;

public interface IDatabaseFactory
{
    Connection CreateConnection();
    Command CreateCommand();
}