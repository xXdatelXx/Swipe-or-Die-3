using UnityEngine;
using System;

public class MonoBehaviourFactory : MonoBehaviour, IMonoBehaviourFactory
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parent;

    private void Awake()
    {
        if (_spawnPoint == null)
            throw new NullReferenceException($"{nameof(_spawnPoint)} == null");
    }

    public T Create<T>(T tObject) where T : MonoBehaviour
    {
        return Instantiate(tObject, _spawnPoint.position, Quaternion.identity, _parent);
    }
}
