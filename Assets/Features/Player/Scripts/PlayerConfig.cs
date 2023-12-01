using System;
using TestTask.Weapon;
using UnityEngine;

namespace TestTask.Player
{
    [Serializable]
    public sealed class PlayerConfig : CharacterBaseConfig<PlayerComponent>
    {
        [SerializeField]
        private WeaponType[] _weapons;

        public WeaponType[] Weapons => _weapons;
    }
}