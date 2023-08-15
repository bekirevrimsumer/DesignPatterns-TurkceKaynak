using AdapterPattern.Adapters;
using AdapterPattern.Databases;

SqlDatabaseAdapter sqlDatabaseAdapter = new(new SqlDatabase());
NoSqlDatabaseAdapter noSqlDatabaseAdapter = new(new NoSqlDatabase());

sqlDatabaseAdapter.ExecuteQuery("SELECT * FROM Users");
noSqlDatabaseAdapter.ExecuteQuery("SELECT * FROM Users");
