namespace IteratorPattern.Interfaces;

public interface IAggregate
{
    IIterator CreateIterator();
}