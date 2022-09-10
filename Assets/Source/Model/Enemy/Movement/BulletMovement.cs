using UnityEngine;
using SwipeOrDie.GameLogic;
using SwipeOrDie.Extension;
using DG.Tweening;
using Sirenix.OdinInspector;

public class BulletMovement : SerializedMonoBehaviour
{
    [SerializeField, Range(0, 100)] private readonly float _speed;
    [SerializeField] private readonly IPosition _position;
    [SerializeField] private IDestroyView _destroyView;

    private void Awake()
    {
        Move();
    }

    private void Move()
    {
        var nextPosition = _position.Next(transform.forward);
        var movingTime = transform.Time(nextPosition, _speed);

        transform.DOMove(nextPosition, movingTime);
        _destroyView.Destroy(movingTime);
    }
}
