using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

namespace TestTask.Player
{
    public sealed class PlayerMovement
    {
        private readonly float _speedMovement;
        private readonly NavMeshAgent _player;

        public PlayerMovement(NavMeshAgent player, float speedMovement)
        {
            _speedMovement = speedMovement;
            _player = player;

            player.speed = speedMovement;
        }

        public void OnMovement(Vector3 direction, float deltaTime)
        {
            _player.transform.Rotate(Vector3.up, 100 * direction.x * deltaTime);
            _player.Move(_speedMovement * deltaTime * _player.transform.forward);
        }
    }
}