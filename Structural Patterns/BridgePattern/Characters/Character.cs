using BridgePattern.Interfaces;

namespace BridgePattern.Characters;

public abstract class Character
{
    public IWeapon Weapon;

    public Character(IWeapon weapon)
    {
        Weapon = weapon;
    }
    
    public abstract void Fight();
}