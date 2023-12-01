using UnityEngine;

namespace TestTask.Weapon
{
    public interface IWeaponFactory
    {
        WeaponModel Get(WeaponType type, Transform parrent, Vector3 pos,
            Vector3 rot);
    }

    public interface IWeaponComponentProvider
    {
        AmmoComponent GetAmmo();
    }
}