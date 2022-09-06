using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SwipeOrDie.Factory
{
    public class MonoBehaviourFactory<T> : IFactory<T> where T : MonoBehaviour
    {
        private readonly Transform _parent;
        private readonly Transform _spawnPoint;

        public MonoBehaviourFactory(Transform spawnPoint, Transform parent)
        {
            _spawnPoint = spawnPoint ? spawnPoint : throw  new ArgumentNullException(nameof(spawnPoint));
            _parent = parent;
        }

        public T Create(T obj)
        {
            return Object.Instantiate(obj, _spawnPoint.position, _spawnPoint.rotation, _parent);
        }
    }
}