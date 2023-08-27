using StatePattern.Interfaces;
using StatePattern.Models;

namespace StatePattern.States;

public class DraftState : IState
{
    public void Publish(Document document)
    {
        Console.WriteLine("Document is in draft state. Cannot publish.");
        document.ChangeState(new ReviewState());
        document.Publish();
    }
}