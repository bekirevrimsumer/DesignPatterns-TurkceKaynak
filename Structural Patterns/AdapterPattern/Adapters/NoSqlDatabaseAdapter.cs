using AdapterPattern.Databases;
using AdapterPattern.Interfaces;

namespace AdapterPattern.Adapters;

public class NoSqlDatabaseAdapter : IDatabaseAdapter
{
    private readonly NoSqlDatabase _noSqlDatabase;

    public NoSqlDatabaseAdapter(NoSqlDatabase noSqlDatabase)
    {
        _noSqlDatabase = noSqlDatabase;
    }

    public void ExecuteQuery(string query)
    {
        _noSqlDatabase.Find(query);
    }
}