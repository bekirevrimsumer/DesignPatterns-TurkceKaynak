using AbstractFactoryPattern.Interfaces;
using AbstractFactoryPattern.Models;

namespace AbstractFactoryPattern;

public class DatabaseOperation
{
    IDatabaseFactory _databaseFactory;
    Connection _connection;
    Command _command;
    
    public DatabaseOperation(IDatabaseFactory databaseFactory)
    {
        _databaseFactory = databaseFactory;
        _connection = _databaseFactory.CreateConnection();
        _command = _databaseFactory.CreateCommand();
    }
    
    public void Add(string query)
    {
        _connection.Connect();
        _command.ExecuteCommand(query);
        _connection.Disconnect();
    }
    
    public void Update(string query)
    {
        _connection.Connect();
        _command.ExecuteCommand(query);
        _connection.Disconnect();
    }
    
    public void Delete(string query)
    {
        _connection.Connect();
        _command.ExecuteCommand(query);
        _connection.Disconnect();
    }
}