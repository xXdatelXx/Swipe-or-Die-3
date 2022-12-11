using System;
using UnityEngine;
using SwipeOrDie.Extension;
using Random = UnityEngine.Random;

namespace SwipeOrDie.Data
{
    [Serializable]
    public sealed class RandomColor : IRandomColor
    {
        [SerializeField] private float _force;

        public RandomColor(float force) => 
            _force = force.ThrowExceptionIfValueSubZero();

        public Color Next()
        {
            float RandomPart() => Random.Range(0, _force);
            return new Color(RandomPart(), RandomPart(), RandomPart());
        }
    }
}