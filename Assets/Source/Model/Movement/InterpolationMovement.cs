using UnityEngine;
using DG.Tweening;
using Source.Model;
using SwipeOrDie.Extension;
using Cysharp.Threading.Tasks;
using Source.Model.Movement.Interface;

public sealed class InterpolationMovement : IMovement
{
    [SerializeField] private readonly Transform _transform;
    [SerializeField] private readonly ISpeed _speed;

    public InterpolationMovement(Transform transform, ISpeed speed)
    {
        _transform = transform;
        _speed = speed;
    }

    public async UniTask Move(Vector3 nextPosition)
    {
        nextPosition = _transform.parent.LocalPosition(nextPosition);
        var movingTime = _transform.Time(nextPosition, _speed);

        await _transform.DOLocalMove(nextPosition, movingTime).AsyncWaitForCompletion();
    }
}