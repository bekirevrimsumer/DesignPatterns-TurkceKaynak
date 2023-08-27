using ICloneable = PrototypePattern.Interfaces.ICloneable;

namespace PrototypePattern.Models;

public class Vehicle : ICloneable
{
    public string Model { get; set; }
    public string Color { get; set; }
    public string Type { get; set; }
    
    public ICloneable Clone()
    {
        return (ICloneable)MemberwiseClone();    
    }
    
    public void Display()
    {
        Console.WriteLine($"Model: {Model}, Color: {Color}, Type: {Type}");
    }
}