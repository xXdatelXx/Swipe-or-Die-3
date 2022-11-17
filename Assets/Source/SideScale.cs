using DG.Tweening;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source
{
    public sealed class SideScale : ISideScale
    {
        private readonly float _force;
        private readonly float _duration;
        private readonly Transform _transform;
        private readonly (Vector3 scale, Vector3 position) _standardValue;

        public SideScale(float force, float duration, Transform transform)
        {
            _force = force.ThrowExceptionIfValueSubZero(nameof(force));
            _duration = duration.ThrowExceptionIfValueSubZero(nameof(duration));
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));
            _standardValue = (_transform.localScale, _transform.localPosition);
        }

        public void Scale(Vector3 direction)
        {
            _transform.DOScale(_standardValue.scale + direction.Module() * _force, _duration);
            _transform.DOLocalMove(_standardValue.position - direction * _force / 2, _duration);
        }

        public void Reset()
        {
            _transform.DOScale(_standardValue.scale, _duration);
            _transform.DOLocalMove(_standardValue.position, _duration);
        }
    }
}