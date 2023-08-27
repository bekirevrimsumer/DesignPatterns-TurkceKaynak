using AbstractFactoryPattern.Interfaces;
using AbstractFactoryPattern.Models;

namespace AbstractFactoryPattern.DatabaseFactories;

public class MySqlDatabaseFactory : IDatabaseFactory
{
    public Connection CreateConnection()
    {
        return new MySqlConnection();
    }

    public Command CreateCommand()
    {
        return new MySqlCommand();
    }
}