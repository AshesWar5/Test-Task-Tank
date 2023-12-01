using UnityEngine;

namespace TestTask.Level 
{
    [CreateAssetMenu(fileName = "LevelFactory", menuName = "Factories/Level")]
    public sealed class LevelFactory : GameObjectFactory
    {
        [SerializeField]
        private FactoryBaseConfig<LevelView>[] _levels;
        
        public LevelView Get(int index)
        {
            var config = _levels[index];
            return CreateGameObjectInstance(config.Prefab, scale:config.Scale);
        }
    }
}
