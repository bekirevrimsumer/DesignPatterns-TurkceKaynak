using FlyweightPattern.Interfaces;

namespace FlyweightPattern.Models;

public class Player
{
    private IParticle _particle;
    
    public Player(IParticle particle)
    {
        _particle = particle;
    }
    
    public void Shoot(Position position)
    {
        _particle.Draw(position);
    }
}