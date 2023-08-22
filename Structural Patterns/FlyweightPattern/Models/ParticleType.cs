using FlyweightPattern.Interfaces;

namespace FlyweightPattern.Models;

public class ParticleType : IParticle
{
    private string _type;
    
    public ParticleType(string type)
    {
        _type = type;
    }
    
    public void Draw(Position position)
    {
        Console.WriteLine($"Drawing {_type} particle at {position.X}, {position.Y}");
    }
}