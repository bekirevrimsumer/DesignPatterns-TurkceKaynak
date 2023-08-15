namespace AdapterPattern.Interfaces;

public interface IDatabaseAdapter
{
    void ExecuteQuery(string query);
}