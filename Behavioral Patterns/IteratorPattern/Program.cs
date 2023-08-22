

using IteratorPattern.Models;

var employeeAggregate = new EmployeeAggregate();
employeeAggregate.Add(new Employee(){ Name = "John", Surname = "Doe", Department = "IT", Title = "Software Developer" });
employeeAggregate.Add(new Employee(){ Name = "Jane", Surname = "Doe", Department = "Marketing", Title = "Marketing Manager" });
employeeAggregate.Add(new Employee(){ Name = "Jack", Surname = "Doe", Department = "IT", Title = "Software Developer" });


var employeeIterator = employeeAggregate.CreateIterator();

while (employeeIterator.HasNext())
{
    var employee = employeeIterator.Next();
    Console.WriteLine($"{employee.Name} {employee.Surname} - {employee.Department} - {employee.Title}");
}