using BuilderPattern.Interface;

namespace BuilderPattern.Models;

public class HawaiianPizzaBuilder : IPizzaBuilder
{
    private Pizza pizza = new Pizza();
    
    public void SetDough()
    {
        pizza.Dough = "cross";
    }

    public void SetSauce()
    {
        pizza.Sauce = "mild";
    }

    public void SetTopping()
    {
        pizza.Topping = "ham+pineapple";
    }

    public Pizza GetPizza()
    {
        return pizza;
    }
}