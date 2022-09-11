using UnityEngine;
using SwipeOrDie.GameLogic;
using SwipeOrDie.Extension;
using DG.Tweening;
using JetBrains.Annotations;
using Sirenix.OdinInspector;

namespace Source.Model.Enemy.Movement
{
    public class BulletMovement : SerializedMonoBehaviour
    {
        [SerializeField] private readonly ISpeed _speed;
        [SerializeField] private readonly IPosition _position;

        private void Awake()
        {
            Move();
        }

        private void Move()
        {
            var nextPosition = _position.Next(transform.forward);
            var movingTime = transform.Time(nextPosition, _speed);

            transform.DOMove(nextPosition, movingTime);
        }
    }
}