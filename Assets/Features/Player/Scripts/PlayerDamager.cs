using TestTask.Enemy;
using UnityEngine;

namespace TestTask
{
    public sealed class PlayerDamager : Damager
    {
        public PlayerDamager(CollisionListener listner, IDamageable damageable)
            : base(listner, damageable) { }

        protected override void OnEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out EnemyComponent enemy) == false)
                return;

            _damageable.TakeDamage(enemy.Damage);
        }
    }
}