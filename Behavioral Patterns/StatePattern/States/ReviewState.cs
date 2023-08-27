using StatePattern.Interfaces;
using StatePattern.Models;

namespace StatePattern.States;

public class ReviewState : IState
{
    public void Publish(Document document)
    {
        Console.WriteLine("Document is under review. Cannot publish.");
        document.ChangeState(new PublishedState());
        document.Publish();
    }
}
