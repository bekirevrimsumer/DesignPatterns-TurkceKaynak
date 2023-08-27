using StatePattern.Interfaces;
using StatePattern.Models;

namespace StatePattern.States;

public class PublishedState : IState
{
    public void Publish(Document document)
    {
        Console.WriteLine("Document is already published.");
    }
}