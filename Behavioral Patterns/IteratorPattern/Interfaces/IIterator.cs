using IteratorPattern.Models;

namespace IteratorPattern.Interfaces;

public interface IIterator
{
    bool HasNext();
    Employee Next();
}