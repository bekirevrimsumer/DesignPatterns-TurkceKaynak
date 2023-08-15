using ChainOfResponsibilityPattern.Interfaces;

namespace ChainOfResponsibilityPattern.Models;

public class Rule
{
    public IRule NextRule { get; set; }
}