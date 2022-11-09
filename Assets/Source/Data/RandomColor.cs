using UnityEngine;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Data
{
    public class RandomColor
    {
        private readonly float _force;

        public RandomColor(float force) => 
            _force = force.ThrowIfValueSubZero();

        public Color Next()
        {
            float RandomPart() => Random.Range(0, _force);

            return new Color(RandomPart(), RandomPart(), RandomPart());
        }
    }
}