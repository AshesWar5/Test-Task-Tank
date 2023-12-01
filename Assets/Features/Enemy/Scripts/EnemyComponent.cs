using System;
using UnityEngine;
using UnityEngine.AI;

namespace TestTask.Enemy
{
    [RequireComponent(typeof(NavMeshAgent), typeof(CollisionListener))]
    public class EnemyComponent : PooledObject, ICleaner, IDamageable
    {
        public event Action Died;

        private int _damage;
        private Health _health;
        private NavMeshAgent _agent;
        private Transform _target;

        public CollisionListener CollisionListener { get; private set; }
        public int Damage => _damage;
        
        public void Initialize(float speed, int damage, Health health)
        {
            _agent = GetComponent<NavMeshAgent>();
            CollisionListener = GetComponent<CollisionListener>();
            _health = health;
            _damage = damage;

            _agent.speed = speed;
            _health.Died += OnDied;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public void Move()
        {
            _agent.SetDestination(_target.position);
        }

        public override void ResetData()
        {
            _health.ResetData();
        }

        public void Cleaner()
        {
            _health.Died -= OnDied;
        }

        void IDamageable.TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        private void OnDied()
        {
            Died?.Invoke();
            ReturnToPool();
        }
    }
}