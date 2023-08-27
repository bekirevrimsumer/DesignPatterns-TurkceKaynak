using PrototypePattern.Models;

Vehicle originalCar = new Vehicle { Type = "Car", Model = "Sedan", Color = "Red"};
originalCar.Display();

Vehicle clonedCar = (Vehicle)originalCar.Clone();
clonedCar.Model = "SUV";
clonedCar.Display();