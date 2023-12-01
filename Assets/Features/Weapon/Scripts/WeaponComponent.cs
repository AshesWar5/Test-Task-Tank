using UnityEngine;

namespace TestTask.Weapon
{
    public sealed class WeaponComponent : MonoBehaviour, IWeaponComponentProvider
    {
        [SerializeField]
        private Transform _pointSpawnAmmo;

        private BaseShoot _shoot;
        private Pool<AmmoComponent> _pool;
        private WeaponModel _model;
        private IAmmoFactory _ammo;

        public Transform PointSpawnAmmo => _pointSpawnAmmo;

        public void Initialize(WeaponModel model, IAmmoFactory ammo, BaseShoot shoot)
        {
            _shoot = shoot;
            _pool = new Pool<AmmoComponent>();
            _model = model;
            _ammo = ammo;
        }

        public void Shoot()
        {
            _shoot.Shoot();
        }

        public void ActivateWeapon()
        {
            _shoot.IsShooting = true;
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            _shoot.IsShooting = false;
            gameObject.SetActive(false);
        }

        public AmmoComponent GetAmmo()
        {
            return _pool.HasInactiveObjects() ? _pool.GetInactiveObject() : CreateAmmo();
        }

        private AmmoComponent CreateAmmo()
        {
            var ammo = _ammo.Get(_model.WeaponType, _pointSpawnAmmo.position);
            ammo.Initialize(_model.Damage);
            _pool.Add(ammo);
            return ammo;
        }
    }
}