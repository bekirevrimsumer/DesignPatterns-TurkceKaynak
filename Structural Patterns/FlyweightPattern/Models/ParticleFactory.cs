using FlyweightPattern.Interfaces;

namespace FlyweightPattern.Models;

public class ParticleFactory
{
    private Dictionary<string, IParticle> _particleTypes = new Dictionary<string, IParticle>();
    
    public IParticle GetParticleType(string type)
    {
        if (!_particleTypes.ContainsKey(type))
        {
            _particleTypes.Add(type, new ParticleType(type));
        }
        
        return _particleTypes[type];
    }
}