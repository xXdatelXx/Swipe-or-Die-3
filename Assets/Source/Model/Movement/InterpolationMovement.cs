using UnityEngine;
using DG.Tweening;
using Source.Model;
using SwipeOrDie.Extension;
using System.Threading.Tasks;
using Source.Model.Movement.Interface;

public class InterpolationMovement : IMovement
{
    private readonly Transform _transform;
    private readonly ISpeed _speed;

    public InterpolationMovement(Transform transform, ISpeed speed)
    {
        _transform = transform;
        _speed = speed;
    }

    public async Task Move(Vector2 nextPosition)
    {
        var movingTime = _transform.Time(nextPosition, _speed);
        await _transform.DOMove(nextPosition, movingTime).AsyncWaitForCompletion();
    }
}