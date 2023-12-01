using TestTask.Weapon;
using UnityEngine;

namespace TestTask.Enemy
{
    public class EnemyDamager : Damager
    {
        public EnemyDamager(CollisionListener listner, IDamageable damageable)
            : base(listner, damageable) { }

        protected override void OnEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out AmmoComponent ammo) == false)
                return;

            ammo.ReturnToPool();
            _damageable.TakeDamage(ammo.Damage);
        }
    }
}