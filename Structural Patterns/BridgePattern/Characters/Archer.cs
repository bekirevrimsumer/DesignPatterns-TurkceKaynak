using BridgePattern.Interfaces;

namespace BridgePattern.Characters;

public class Archer : Character
{
    public Archer(IWeapon weapon) : base(weapon)
    {
    }

    public override void Fight()
    {
        Weapon.Attack();
    }
}