using UnityEngine;

namespace TestTask.Player
{
    [CreateAssetMenu(fileName = "Player Factory", menuName = "Factories/Player")]
    public sealed class PlayerFactory : GameObjectFactory
    {
        [SerializeField]
        private PlayerConfig _player;

        public PlayerModel Get(Vector3 pos, Vector3 rot)
        {
            var instance = CreateGameObjectInstance(_player.Prefab, pos: pos, rot: rot,
                scale: _player.Scale);
            return new PlayerModel(instance, _player.Health, _player.Protection, _player.SpeedMovement,
                _player.Weapons);
        }
    }
}