using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using random = UnityEngine.Random;

namespace TestTask.Enemy
{
    public sealed class EnemySpawn
    {
        private readonly IEnemyFactory _factory;
        private readonly Pool<EnemyComponent> _pool;
        private readonly int _maxCountEnemy;
        private readonly Transform[] _pointsEnemy;

        private const int MAX_COUNT_SPAWN_ONE_FRAME = 10;

        public EnemySpawn(IEnemyFactory factory, Pool<EnemyComponent> pool,
            int maxCountEnemy, Transform[] pointsEnemy, AsyncTaskService asyncTask)
        {
            _factory = factory;
            _pool = pool;
            _maxCountEnemy = maxCountEnemy;
            _pointsEnemy = pointsEnemy;
        }

        public IEnumerator SpawnEnemys(Action<IEnumerable<EnemyComponent>> callback)
        {
            int maxCountSpawnOneFrame = MAX_COUNT_SPAWN_ONE_FRAME;
            List<EnemyComponent> enemys = new List<EnemyComponent>();

            for (int i = 0; i < _maxCountEnemy * 2; i++)
            {
                if(maxCountSpawnOneFrame > 0)
                {
                    EnemyType type = (EnemyType)random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
                    var enemy = _factory.Get(type, RandomPos(), Vector3.zero);
                    var health = new Health(enemy.Health, enemy.Protection);
                    enemy.Enemy.Initialize(enemy.SpeedMovement, enemy.Damage, health);
                    new EnemyDamager(enemy.Enemy.CollisionListener, enemy.Enemy);
                    _pool.Add(enemy.Enemy);
                    maxCountSpawnOneFrame--;
                    enemys.Add(enemy.Enemy);

                    if(i > _maxCountEnemy)
                    {
                        enemy.Enemy.ReturnToPool();
                    }
                }
                else
                {
                    yield return null;
                    maxCountSpawnOneFrame = MAX_COUNT_SPAWN_ONE_FRAME;
                }
            }

            callback?.Invoke(enemys);
        }

        public void SpawnEnemy()
        {
            var enemy = _pool.GetInactiveObject();
            enemy.transform.position = RandomPos();
            enemy.ResetData();
        }

        private Vector3 RandomPos()
        {
            return _pointsEnemy[random.Range(0, _pointsEnemy.Length)].position;
        }
    }
}