using UnityEngine;

namespace TestTask
{
    public abstract class Damager
    {
        protected IDamageable _damageable;

        public Damager(CollisionListener listner, IDamageable damageable)
        {
            _damageable = damageable;

            listner.Enter += OnEnter;
        }

        protected abstract void OnEnter(Collision collision);
    }
}