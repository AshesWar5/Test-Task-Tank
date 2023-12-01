using UnityEngine;

namespace TestTask.Weapon
{
    public class BaseShoot
    {
        public bool IsShooting { get; set; }

        private readonly Transform _pointSpawn;
        private readonly IWeaponComponentProvider _weapon;

        private const float FORCE_MOVEMENT_AMMO = 800;

        public BaseShoot(IWeaponComponentProvider weapon, Transform pointSpawn)
        {
            _pointSpawn = pointSpawn;
            _weapon = weapon;
        }

        public virtual void Shoot()
        {
            if (IsShooting == false)
                return;

            var ammo = _weapon.GetAmmo();
            ammo.transform.position = _pointSpawn.position;
            ammo.AddForce(_pointSpawn.forward, FORCE_MOVEMENT_AMMO);
        }
    }
}