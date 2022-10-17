using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FluentValidation;
using Sirenix.OdinInspector;
using UnityEngine;
using Source.Model.Movement.Interface;

namespace Source.Model.Enemy.Movement
{
    public class LopedMovement : SerializedMonoBehaviour
    {
        [SerializeField] private List<Transform> _point = new();
        [SerializeField, Min(0)] private float _delay;
        [SerializeField] private IMovement _movement;

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
                    await _movement.Move(nextPoint.localPosition);
                    await UniTask.Delay(TimeSpan.FromSeconds(_delay));
                }
            }
        }

        private class Validator : AbstractValidator<LopedMovement>
        {
            public Validator()
            {
                RuleFor(move => move._point).NotNull();
                RuleFor(move => move._delay).GreaterThanOrEqualTo(0);
                RuleFor(move => move._movement).NotNull();
            }
        }
    }
}