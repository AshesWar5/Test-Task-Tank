using System;

namespace TestTask
{
    public sealed class Health : IReset
    {
        public event Action Died;
        public event Action<float> Changed;

        private float _health;
        private float _protection;

        private float _resetHealth;
        private float _resetProtection;

        public float _Health => _health;

        public Health(float health, float protection) 
        {
            _health = health;
            _protection = protection;

            _resetHealth = health;
            _resetProtection = protection;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage - (damage * _protection);
            Changed?.Invoke(_health);

            if(IsDied() == true)
            {
                Died?.Invoke();
            }
        }

        public void ResetData()
        {
            _health = _resetHealth;
            _protection = _resetProtection;
        }

        private bool IsDied()
        {
            return _health <= 0;
        }
    }
}