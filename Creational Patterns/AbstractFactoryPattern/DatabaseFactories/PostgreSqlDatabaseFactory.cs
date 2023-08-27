using AbstractFactoryPattern.Interfaces;
using AbstractFactoryPattern.Models;

namespace AbstractFactoryPattern.DatabaseFactories;

public class PostgreSqlDatabaseFactory : IDatabaseFactory
{
    public Connection CreateConnection()
    {
        return new PostgreSqlConnection();
    }

    public Command CreateCommand()
    {
        return new PostgreSqlCommand();
    }
}