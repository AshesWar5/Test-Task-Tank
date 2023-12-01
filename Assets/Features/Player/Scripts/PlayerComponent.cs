using TestTask.UI;
using TestTask.UI.ProgressBar;
using UnityEngine;
using UnityEngine.AI;

namespace TestTask.Player
{
    [RequireComponent(typeof(CollisionListener), typeof(NavMeshAgent))]
    public sealed class PlayerComponent : MonoBehaviour, ICleaner, IDamageable
    {
        [SerializeField]
        private Transform _pointWeapon;
        [SerializeField]
        private CollisionListener _collisionListener;
        [SerializeField]
        private NavMeshAgent _agent;
        [SerializeField]
        private SliderUIView _healthProgressBar;

        private PlayerMovement _movement;
        private IInput _input;
        private Health _health;
        private ILoseScreenProvider _loseScreen;

        public CollisionListener CollisionListener => _collisionListener;
        public NavMeshAgent Agent => _agent;
        public Transform PointWeapon => _pointWeapon;

        public void Initialize(IInput input, PlayerMovement movement, Health health,
            ILoseScreenProvider loseScreen)
        {
            _input = input;
            _movement = movement;
            _health = health;
            _loseScreen = loseScreen;

            _healthProgressBar.Initialize(health._Health, health._Health);

            input.Movemnet += _movement.OnMovement;
            health.Died += OnDiedPlayer;
            health.Changed += _healthProgressBar.UpdateValue;
        }

        public void Cleaner()
        {
            _input.Movemnet -= _movement.OnMovement;
            _health.Died -= OnDiedPlayer;
            _health.Changed -= _healthProgressBar.UpdateValue;
        }

        void IDamageable.TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        private void OnDiedPlayer()
        {
            Cleaner();
            _loseScreen.ShowLoseScreen();
            gameObject.SetActive(false);
        }
    }
}