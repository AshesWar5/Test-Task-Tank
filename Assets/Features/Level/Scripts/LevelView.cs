using UnityEngine;

namespace TestTask.Level
{
    public sealed class LevelView : MonoBehaviour
    {
        [SerializeField]
        private Transform _startPointPlayer;
        [SerializeField]
        private Transform[] _pointsForEnemys;

        public Transform StatPointPlayer => _startPointPlayer;
        public Transform[] PointsForEnemys => _pointsForEnemys;
    }
}