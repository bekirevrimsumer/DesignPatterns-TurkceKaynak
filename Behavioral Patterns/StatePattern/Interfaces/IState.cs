using StatePattern.Models;

namespace StatePattern.Interfaces;

public interface IState
{
    void Publish(Document document);
}