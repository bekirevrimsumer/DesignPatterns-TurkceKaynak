using TemplatePattern.Models;

Console.WriteLine("Making coffee:");
Coffee coffee = new Coffee();
coffee.MakeHotDrink();

Console.WriteLine("\nMaking tea:");
Tea tea = new Tea();
tea.MakeHotDrink();