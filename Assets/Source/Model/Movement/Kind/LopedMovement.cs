using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using FluentValidation;
using Sirenix.OdinInspector;
using SwipeOrDie.Extension;
using UnityEngine;

namespace Source.Model.Enemy.Movement
{
    public class LopedMovement : SerializedMonoBehaviour
    {
        [SerializeField] private List<Transform> _point = new();
        [SerializeField] private ISpeed _speed;
        [SerializeField, Min(0)] private float _delay;

        private void Awake()
        {
            new Validator().ValidateAndThrow(this);

            Move();
        }

        private async void Move()
        {
            while (true)
            {
                foreach (var nextPoint in _point)
                {
                    var movingTime = transform.Time(nextPoint, _speed);

                    transform.DOLocalMove(nextPoint.localPosition, movingTime);
                    await UniTask.Delay(TimeSpan.FromSeconds(movingTime + _delay));
                }
            }
        }

        private class Validator : AbstractValidator<LopedMovement>
        {
            public Validator()
            {
                RuleFor(move => move._speed).NotNull();
                RuleFor(move => move._point).NotNull();
                RuleFor(move => move._delay).GreaterThanOrEqualTo(0);
            }
        }
    }
}