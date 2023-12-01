using System;
using UnityEngine;

namespace TestTask.Weapon
{
    [Serializable]
    public sealed class WeaponConfig : FactoryBaseConfig<WeaponComponent>
    {
        [SerializeField]
        private int _damage;
        [SerializeField]
        private AmmoComponent _ammo;

        public int Damage => _damage;
        public AmmoComponent Ammo => _ammo;
    }
}
