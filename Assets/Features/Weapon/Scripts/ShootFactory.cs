using UnityEngine;

namespace TestTask.Weapon
{
    public sealed class ShootFactory
    {
        public BaseShoot Get(WeaponType type, IWeaponComponentProvider weaponProvider,
            Transform pointSpawn)
        {
            return new BaseShoot(weaponProvider, pointSpawn);
        }
    }
}