using System;
using UnityEngine;

namespace TestTask
{
    public sealed class CollisionListener : MonoBehaviour
    {
        public event Action<Collision> Enter;

        private void OnCollisionEnter(Collision collision)
        {
            Enter?.Invoke(collision);
        }
    }
}