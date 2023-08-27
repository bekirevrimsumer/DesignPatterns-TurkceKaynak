namespace TemplatePattern.Models;

public class Coffee : HotDrinkTemplate
{
    protected override void BrewCoffee()
    {
        Console.WriteLine("Dripping coffee through filter");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk");
    }
}