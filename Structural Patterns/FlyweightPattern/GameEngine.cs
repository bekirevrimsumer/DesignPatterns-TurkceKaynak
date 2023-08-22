using FlyweightPattern.Models;

namespace FlyweightPattern;

public class GameEngine
{
    private ParticleFactory _particleFactory = new ParticleFactory();
    
    public void Run()
    {
        var player1 = new Player(_particleFactory.GetParticleType("bullet"));
        player1.Shoot(new Position(10, 10));
        player1.Shoot(new Position(100, 100));
        
        var player2 = new Player(_particleFactory.GetParticleType("bullet"));
        player2.Shoot(new Position(20, 20));
        player2.Shoot(new Position(200, 200));
        
        var player3 = new Player(_particleFactory.GetParticleType("laser"));
        player3.Shoot(new Position(30, 30));
        player3.Shoot(new Position(300, 300));
    }
}