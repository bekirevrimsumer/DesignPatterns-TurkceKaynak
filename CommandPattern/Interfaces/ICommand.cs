namespace CommandPattern.Interfaces;

public interface ICommand
{
    double Execute(double value);
    double Rollback(double value);
}