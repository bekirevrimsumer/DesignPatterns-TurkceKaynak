using BridgePattern.Interfaces;

namespace BridgePattern.Characters;

public class Warrior : Character
{
    public Warrior(IWeapon weapon) : base(weapon)
    {
    }

    public override void Fight()
    {
        Weapon.Attack();
    }
}