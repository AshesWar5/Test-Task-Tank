using System;
using UnityEngine;

namespace TestTask
{
    [Serializable]
    public class CharacterBaseConfig<T> : FactoryBaseConfig<T> where T : MonoBehaviour
    {
        [SerializeField]
        private float _health;
        [SerializeField, Range(0, 1)]
        private float _protection;
        [SerializeField]
        private float _speedMovement;

        public float Health => _health;
        public float Protection => _protection;
        public float SpeedMovement => _speedMovement;
    }
}