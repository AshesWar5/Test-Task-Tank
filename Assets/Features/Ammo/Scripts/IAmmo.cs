using UnityEngine;

namespace TestTask.Weapon
{
    public interface IAmmoFactory
    {
        AmmoComponent Get(WeaponType type, Vector3 pos);
    }
}