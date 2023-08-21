using BridgePattern.Interfaces;

namespace BridgePattern.Weapons;

public class Sword : IWeapon
{
    public void Attack()
    {
        Console.WriteLine("Sword Attack");
    }
}