
using BridgePattern.Characters;
using BridgePattern.Interfaces;
using BridgePattern.Weapons;

IWeapon sword = new Sword();
IWeapon bow = new Bow();

Character knight = new Warrior(sword);
Character archer = new Archer(bow);

knight.Fight();
archer.Fight();