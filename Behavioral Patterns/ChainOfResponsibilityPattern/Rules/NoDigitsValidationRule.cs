using ChainOfResponsibilityPattern.Interfaces;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Rules;

public class NoDigitsValidationRule : Rule, IRule
{
    public NoDigitsValidationRule()
    {
        NextRule = new NoUpperCaseValidationRule();
    }
    
    public bool Handle(RequestModel request)
    {
        if (request.Name.Any(char.IsDigit))
        {
            Console.WriteLine("Name must not contain digits.");
            return false;
        }

        if (NextRule != null)
        {
            return NextRule.Handle(request);
        }

        return true;
    }
}