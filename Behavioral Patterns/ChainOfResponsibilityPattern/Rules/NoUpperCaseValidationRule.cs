using ChainOfResponsibilityPattern.Interfaces;
using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Rules;

public class NoUpperCaseValidationRule : Rule, IRule
{
    public NoUpperCaseValidationRule()
    {
        NextRule = null;
    }
    
    public bool Handle(RequestModel request)
    {
        if (request.Name.Any(char.IsUpper))
        {
            Console.WriteLine("Name must not contain upper case characters.");
            return false;
        }

        if (NextRule != null)
        {
            return NextRule.Handle(request);
        }

        return true;
    }
}