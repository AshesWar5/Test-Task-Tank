using UnityEngine;

namespace TestTask.Enemy
{
    [CreateAssetMenu(fileName = "Enemy Factory", menuName = "Factories/Enemy")]
    public sealed class EnemyFactory : GameObjectFactory, IEnemyFactory
    {
        [SerializeField]
        private EnemyConfigsDatabase _database;

        public EnemyModel Get(EnemyType type, Vector3 pos, Vector3 rot)
        {
            var config = _database.Get(type);
            var instance = CreateGameObjectInstance(config.Prefab, pos:pos, rot:rot,
                scale:config.Scale);
            var model = new EnemyModel(instance, config.Health, config.Protection, config.SpeedMovement,
                config.Damage);
            return model;
        }
    }
}
