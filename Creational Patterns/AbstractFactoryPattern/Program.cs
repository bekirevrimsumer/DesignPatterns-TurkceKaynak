

using AbstractFactoryPattern;
using AbstractFactoryPattern.DatabaseFactories;

var mySqlOperation = new DatabaseOperation(new MySqlDatabaseFactory());
mySqlOperation.Add("INSERT INTO table VALUES (1, 'MySql')");
mySqlOperation.Update("UPDATE table SET name = 'MySql' WHERE id = 1");
mySqlOperation.Delete("DELETE FROM table WHERE id = 1");

var postgreSqlOperation = new DatabaseOperation(new PostgreSqlDatabaseFactory());
postgreSqlOperation.Add("INSERT INTO table VALUES (1, 'PostgreSql')");
postgreSqlOperation.Update("UPDATE table SET name = 'PostgreSql' WHERE id = 1");
postgreSqlOperation.Delete("DELETE FROM table WHERE id = 1");
