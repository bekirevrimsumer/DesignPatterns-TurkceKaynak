using BuilderPattern.Interface;

namespace BuilderPattern.Models;

public class CookManager
{
    private IPizzaBuilder _pizzaBuilder;
    
    public CookManager(IPizzaBuilder pizzaBuilder)
    {
        _pizzaBuilder = pizzaBuilder;
    }
    
    public void MakePizza()
    {
        _pizzaBuilder.SetDough();
        _pizzaBuilder.SetSauce();
        _pizzaBuilder.SetTopping();
    }
    
    public Pizza GetPizza()
    {
        return _pizzaBuilder.GetPizza();
    }
}