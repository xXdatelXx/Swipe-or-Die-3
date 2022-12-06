using SwipeOrDie.Extension;
using UnityEngine;
using Random = System.Random;

namespace SwipeOrDie.Model
{
    public sealed class RandomDestroy : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private int _chance;
        private readonly Random _random = new();

        private void Awake()
        {
            if (_random.Percent() > _chance)
                Destroy(gameObject);
        }
    }
}