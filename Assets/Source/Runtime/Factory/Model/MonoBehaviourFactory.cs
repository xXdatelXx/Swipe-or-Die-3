using SwipeOrDie.Extension;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SwipeOrDie.Factory
{
    public sealed class MonoBehaviourFactory<T> : IGenericFactory<T> where T : MonoBehaviour
    {
        private readonly Transform _parent;
        private readonly Transform _spawnPoint;

        public MonoBehaviourFactory(Transform spawnPoint) : this(spawnPoint, spawnPoint)
        {
        }

        public MonoBehaviourFactory(Transform spawnPoint, Transform parent)
        {
            _spawnPoint = spawnPoint.ThrowExceptionIfNull();
            _parent = parent;
        }

        public T Create(T obj) => 
            Object.Instantiate(obj, _spawnPoint.position, _spawnPoint.rotation, _parent);
    }
}