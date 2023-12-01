using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Weapon
{
    public sealed class WeaponSystem : ICleaner
    {
        private readonly List<WeaponComponent> _weapons;
        private readonly IInput _input;
        private readonly WeaponsSwitch _switch;

        public WeaponSystem(IInput input, WeaponType[] weapons, IWeaponFactory weapon,
            IAmmoFactory ammo, ShootFactory shoot, Transform parrentWeapon)
        {
            _weapons = new List<WeaponComponent>();
            _input = input;

            foreach(var w in weapons)
            {
                var model = weapon.Get(w, parrentWeapon, parrentWeapon.position, parrentWeapon.eulerAngles);
                var s = shoot.Get(w, model.Weapon, model.Weapon.PointSpawnAmmo);
                input.Shoot += model.Weapon.Shoot;
                model.Weapon.Initialize(model, ammo, s);
                _weapons.Add(model.Weapon);
            }

            _switch = new WeaponsSwitch(_weapons.ToArray());
            input.SwitchWeapon += _switch.OnSwitchWeapon;
        }

        public void Cleaner()
        {
            foreach (var weapon in _weapons)
            {
                _input.Shoot -= weapon.Shoot;
            }

            _input.SwitchWeapon -= _switch.OnSwitchWeapon;
        }
    }
}