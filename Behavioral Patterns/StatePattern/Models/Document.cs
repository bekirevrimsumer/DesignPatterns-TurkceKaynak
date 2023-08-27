using StatePattern.Interfaces;
using StatePattern.States;

namespace StatePattern.Models;

public class Document
{
    private IState currentState;

    public Document()
    {
        currentState = new DraftState();
    }

    public void ChangeState(IState newState)
    {
        currentState = newState;
    }

    public void Publish()
    {
        currentState.Publish(this);
    }
}