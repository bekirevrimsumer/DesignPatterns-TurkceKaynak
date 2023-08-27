namespace TemplatePattern.Models;

public abstract class HotDrinkTemplate
{
    public void MakeHotDrink()
    {
        BoilWater();
        BrewCoffee();
        PourInCup();
        AddCondiments();
    }
    
    protected void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }
    
    protected abstract void BrewCoffee();
    
    protected void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }
    
    protected abstract void AddCondiments();
}