using ChainOfResponsibilityPattern.Interfaces;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Rules;

public class MinLengthValidationRule : Rule, IRule
{
    private readonly int _minLength;

    public MinLengthValidationRule(int minLength)
    {
        _minLength = minLength;
        NextRule = new NoDigitsValidationRule();
    }

    public bool Handle(RequestModel request)
    {
        if (request.Name.Length < _minLength)
        {
            Console.WriteLine($"Name must be at least {_minLength} characters long.");
            return false;
        }

        if (NextRule != null)
        {
            return NextRule.Handle(request);
        }

        return true;
    }
}