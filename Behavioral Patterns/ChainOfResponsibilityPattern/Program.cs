
using ChainOfResponsibilityPattern.Interfaces;
using ChainOfResponsibilityPattern.Models;
using ChainOfResponsibilityPattern.Rules;

var requestModel = new RequestModel() { Name = "john wick" };

IRule rule = new MinLengthValidationRule(6);
while (rule.NextRule != null)
{
    if (rule.Handle(requestModel))
    {
        rule = rule.NextRule;
    }
    else
    {
        Console.WriteLine("Validation failed.");
        break;
    }
}

if (rule.NextRule == null)
{
    if (rule.Handle(requestModel))
    {
        Console.WriteLine("Validation succeeded.");
    }
    else
    {
        Console.WriteLine("Validation failed.");
    }
}