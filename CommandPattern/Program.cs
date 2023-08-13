using CommandPattern.Commands;
using CommandPattern.Models;

Calculator calculator = new();
calculator.ExecuteCommand(new AddCommand(10));
calculator.ExecuteCommand(new MultiplyCommand(2));
calculator.ExecuteCommand(new DivideCommand(3));
calculator.Rollback();