using UnityEngine;

namespace TestTask.Enemy
{
    [CreateAssetMenu(fileName = "Enemy Database", menuName = "Database/Enemy")]
    public sealed class EnemyConfigsDatabase : ScriptableObject
    {
        [SerializeField]
        private EnemyConfig _capsule, _cylinder;

        public EnemyConfig Get(EnemyType type)
        {
            switch(type)
            {
                case EnemyType.Capsule:
                    return _capsule;
                case EnemyType.Cylinder:
                    return _cylinder;
            }

            Debug.LogError($"Config by Enemy Type: {type} not found!");
            return null;
        }
    }
}