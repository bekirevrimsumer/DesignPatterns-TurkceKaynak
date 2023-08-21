using BridgePattern.Interfaces;

namespace BridgePattern.Weapons;

public class Bow : IWeapon
{
    public void Attack()
    {
        Console.WriteLine("Bow Attack");
    }
}