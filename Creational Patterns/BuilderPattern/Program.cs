using BuilderPattern.Interface;
using BuilderPattern.Models;

IPizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
CookManager cook = new CookManager(hawaiianPizzaBuilder);

cook.MakePizza();
Pizza pizza = cook.GetPizza();
pizza.Display();