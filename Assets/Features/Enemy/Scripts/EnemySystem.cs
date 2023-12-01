using System.Collections;
using System.Linq;
using UnityEngine;

namespace TestTask.Enemy
{
    public sealed class EnemySystem : IGameUpdate, ICleaner
    {
        private EnemyComponent[] _enemys;
        private readonly EnemySpawn _spawn;
        private readonly Transform _targetEnemy;

        public EnemySystem(IEnemyFactory factory, int maxCountEnemy, Transform[] pointsEnemy,
            AsyncTaskService asyncTask, Transform targetEnemy)
        {
            var pool = new Pool<EnemyComponent>();
            _spawn = new EnemySpawn(factory, pool, maxCountEnemy, pointsEnemy, asyncTask);
            _targetEnemy = targetEnemy;

            asyncTask.StartCoroutine(Initialize());
        }

        private IEnumerator Initialize()
        {
            yield return _spawn.SpawnEnemys((enemys) =>
            {
                foreach (var enemy in enemys)
                {
                    enemy.SetTarget(_targetEnemy);
                    enemy.Died += OnDiedEnemy;
                }

                _enemys = enemys.ToArray();
            });
        }

        public void GameUpdate(float deltaTime)
        {
            if (_enemys != null)
            {
                for (int i = 0; i < _enemys.Count(); i++)
                {
                    if (_enemys[i].isActiveAndEnabled)
                    {
                        _enemys[i].Move();
                    }
                }
            }
        }

        public void Cleaner()
        {
            foreach (var enemy in _enemys)
            {
                enemy.Died -= OnDiedEnemy;
            }
        }

        private void OnDiedEnemy()
        {
            _spawn.SpawnEnemy();
        }
    }
}