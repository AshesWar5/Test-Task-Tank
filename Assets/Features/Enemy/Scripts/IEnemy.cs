using UnityEngine;

namespace TestTask.Enemy
{
    public interface IEnemyFactory
    {
        EnemyModel Get(EnemyType type, Vector3 pos, Vector3 rot);
    }
}