using CompositePattern.Interfaces;
using CompositePattern.Models;

var ceo = new Manager("John", "CEO");

var hrManager = new Manager("Anna", "HR Manager");
hrManager.AddSubordinate(new Employee("Emma", "HR Specialist"));
hrManager.AddSubordinate(new Employee("Mike", "HR Coordinator"));

var itManager = new Manager("Mark", "IT Manager");
itManager.AddSubordinate(new Employee("Alex", "Software Developer"));
itManager.AddSubordinate(new Employee("Laura", "QA Engineer"));

ceo.AddSubordinate(hrManager);
ceo.AddSubordinate(itManager);

DisplayTree(ceo, 0);

static void DisplayTree(IEmployee employee, int depth)
{
    string indentation = new string('-', depth);
    Console.WriteLine($"{indentation}{employee.GetType().Name}: {employee.GetNameAndPosition()}");

    if (employee is Manager manager)
    {
        foreach (var subordinate in manager.GetSubordinates())
        {
            DisplayTree(subordinate, depth + 1);
        }
    }
}

// ----- OUTPUT -----
// Manager: John - CEO
// -Manager: Anna - HR Manager
// --Employee: Emma - HR Specialist
// --Employee: Mike - HR Coordinator
// -Manager: Mark - IT Manager
// --Employee: Alex - Software Developer
// --Employee: Laura - QA Engineer
