using System;
using UnityEngine;

namespace TestTask
{
    public interface IInput
    {
        event Action<Vector3, float> Movemnet;
        event Action<int> SwitchWeapon;
        event Action Shoot;
    }

    public sealed class PCInput : IInput, IGameUpdate
    {
        public event Action<Vector3, float> Movemnet;
        public event Action<int> SwitchWeapon;
        public event Action Shoot;

        private Vector3 _directionMovement;

        public void Initialize()
        {
            _directionMovement = new Vector3();
        }

        void IGameUpdate.GameUpdate(float deltaTime)
        {
            _directionMovement.x = Input.GetAxisRaw("Horizontal");
            _directionMovement.z = Input.GetAxisRaw("Vertical");
            if (Math.Abs(_directionMovement.magnitude)  > 0.1f)
            {
                Movemnet?.Invoke(_directionMovement, deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchWeapon?.Invoke(-1);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                SwitchWeapon?.Invoke(1);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                Shoot?.Invoke();
            }
        }
    }
}