using ChainOfResponsibilityPattern.Models;

namespace ChainOfResponsibilityPattern.Interfaces;

public interface IRule
{
    IRule NextRule { get; set; }
    bool Handle(RequestModel request);
}