using System.Collections.Generic;
using UnityEngine;

namespace TestTask
{
    public interface IGameUpdate
    {
        void GameUpdate(float deltaTime);
    }

    public sealed class CollectionUpdate : MonoBehaviour, ICleaner
    {
        private List<IGameUpdate> _updates;
        private bool _isStoped;

        public void Initialize()
        {
            _updates = new List<IGameUpdate>();
        }

        public void Cleaner()
        {
            _updates.Clear();
            _isStoped = true;
        }

        public void AddToUpdateList(IGameUpdate update)
        {
            if (_updates.Contains(update) == false)
            {
                _updates.Add(update);
            }
        }

        public void RemoveFromUpdateList(IGameUpdate update)
        {
            _updates.Remove(update);
        }

        public void UpdateStopUpdate(bool stop)
        {
            _isStoped = stop;
        }

        private void Update()
        {
            if (_isStoped == true) return;

            for (int i = 0; i < _updates.Count; i++)
            {
                _updates[i].GameUpdate(Time.deltaTime);
            }
        }
    }
}