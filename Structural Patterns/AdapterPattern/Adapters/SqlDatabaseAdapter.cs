using AdapterPattern.Databases;
using AdapterPattern.Interfaces;

namespace AdapterPattern.Adapters;

public class SqlDatabaseAdapter : IDatabaseAdapter
{
    private readonly SqlDatabase _sqlDatabase;

    public SqlDatabaseAdapter(SqlDatabase sqlDatabase)
    {
        _sqlDatabase = sqlDatabase;
    }

    public void ExecuteQuery(string query)
    {
        _sqlDatabase.Query(query);
    }
}