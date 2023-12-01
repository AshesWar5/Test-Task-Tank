using System;
using UnityEngine;

namespace TestTask
{
    [Serializable]
    public class FactoryBaseConfig<T> where T : MonoBehaviour
    {
        [SerializeField]
        private T _prefab;
        [SerializeField]
        private float _scale;

        public T Prefab => _prefab;
        public float Scale => _scale;
    }
}