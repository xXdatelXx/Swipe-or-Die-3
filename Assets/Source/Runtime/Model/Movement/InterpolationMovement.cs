using UnityEngine;
using DG.Tweening;
using SwipeOrDie.Extension;
using Cysharp.Threading.Tasks;

namespace SwipeOrDie.Model
{
    public sealed class InterpolationMovement : IMovement
    {
        [SerializeField] private readonly Transform _transform;
        [SerializeField] private readonly ISpeed _speed;

        public InterpolationMovement(Transform transform, ISpeed speed)
        {
            _transform = transform.ThrowExceptionIfArgumentNull(nameof(transform));
            _speed = speed.ThrowExceptionIfArgumentNull(nameof(_speed));
        }

        public async UniTask Move(Vector3 nextPosition)
        {
            nextPosition = _transform.parent.LocalPosition(nextPosition);
            var movingTime = _transform.TimeTo(nextPosition, _speed);

            await _transform.DOLocalMove(nextPosition, movingTime).AsyncWaitForCompletion();
        }
    }
}