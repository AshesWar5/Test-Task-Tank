using UnityEngine;

namespace TestTask.Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class AmmoComponent : PooledObject
    {
        public int Damage { get; private set; }

        private Rigidbody _rigidbody;

        public void Initialize(int damage)
        {
            _rigidbody = GetComponent<Rigidbody>();
            Damage = damage;
        }

        public void AddForce(Vector3 direction, float force)
        {
            _rigidbody.AddForce(direction * force);
        }

        public override void ResetData()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        private void Update()
        {
            if(transform.position.y < -5)
            {
                ReturnToPool();
            }
        }
    }
}