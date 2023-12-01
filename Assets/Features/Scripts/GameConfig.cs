using UnityEngine;

namespace TestTask
{
    [CreateAssetMenu(fileName = "Game Config", menuName = "Config/Game")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField]
        private int _indexLevel = 0;

        [SerializeField]
        private int _maxCountEnemy = 10;

        public int MaxCountEnemy => _maxCountEnemy;
        public int IndexLevel => _indexLevel;
    }
}