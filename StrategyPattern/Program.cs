using StrategyPattern.Interfaces;
using StrategyPattern.Strategies;

IDatabaseStrategy sqlServerStrategy = new SqlServerStrategy();
IDatabaseStrategy oracleStrategy = new OracleStrategy();

ConnectToDatabase(sqlServerStrategy);
QueryDatabase(sqlServerStrategy, "SELECT * FROM Customers");

ConnectToDatabase(oracleStrategy);
QueryDatabase(oracleStrategy, "SELECT * FROM Customers");
return;

void ConnectToDatabase(IDatabaseStrategy databaseStrategy)
{
    databaseStrategy.Connect();
}

void QueryDatabase(IDatabaseStrategy databaseStrategy, string query)
{
    databaseStrategy.Query(query);
}