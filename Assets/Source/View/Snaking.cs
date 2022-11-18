using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.View
{
    public sealed class Snaking : MonoBehaviour, ISnaking
    {
        [SerializeField] private float _force;
        [SerializeField, Min(0)] private float _duration;

        public void Snake(Vector3 direction) =>
            transform.DOYOYOMove(direction * _force, _duration);
    }
}