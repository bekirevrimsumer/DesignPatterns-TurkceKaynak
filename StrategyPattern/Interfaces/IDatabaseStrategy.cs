namespace StrategyPattern.Interfaces;

public interface IDatabaseStrategy
{
    void Connect();
    void Query(string query);
}