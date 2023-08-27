using BuilderPattern.Models;

namespace BuilderPattern.Interface;

public interface IPizzaBuilder
{
    public void SetDough();
    public void SetSauce();
    public void SetTopping();
    public Pizza GetPizza();
}