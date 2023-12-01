using System.Collections.Generic;
using UnityEngine;

namespace TestTask
{
    public interface IPoolReturn
    {
        void ReturnToPool(PooledObject obj);
    }

    public sealed class Pool<T> : IPoolReturn where T : PooledObject
    {
        private readonly Queue<T> _inactiveObjects = new Queue<T>();

        public void Add(T obj)
        {
            obj.AssignPool(this);
        }

        public void ReturnToPool(PooledObject obj)
        {
            obj.Disable();
            _inactiveObjects.Enqueue((T)obj);
        }

        public bool HasInactiveObjects()
        {
            return _inactiveObjects.Count > 0;
        }

        public T GetInactiveObject()
        {
            var inactiveObject = _inactiveObjects.Dequeue();
            inactiveObject.Enable();
            return inactiveObject;
        }
    }

    public abstract class PooledObject : MonoBehaviour, IReset
    {
        private IPoolReturn _pool;

        public void AssignPool(IPoolReturn pool)
        {
            _pool = pool;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public virtual void ResetData() { }

        public void ReturnToPool()
        {
            _pool.ReturnToPool(this);
            ResetData();
        }
    }
}