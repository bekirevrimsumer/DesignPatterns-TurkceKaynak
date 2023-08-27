namespace TemplatePattern.Models;

public class Tea : HotDrinkTemplate
{
    protected override void BrewCoffee()
    {
        Console.WriteLine("Steeping the tea");
    }
    
    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon");
    }
}
