using System;
using UnityEngine;

namespace TestTask.Enemy
{
    [Serializable]
    public sealed class EnemyConfig : CharacterBaseConfig<EnemyComponent>
    {
        [SerializeField]
        private int _damage;

        public int Damage => _damage;
    }
}