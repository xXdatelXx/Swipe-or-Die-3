using System.Collections.Generic;
using System.Collections;
using Cysharp.Threading.Tasks;
using FluentValidation;
using ModestTree;
using Sirenix.OdinInspector;
using UnityEngine;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Model
{
    public sealed class LopedMovement : SerializedMonoBehaviour
    {
        [SerializeField] private List<Transform> _points = new();
        [SerializeField, Min(0)] private float _delay;
        [SerializeField] private IMovement _movement;

        private void Awake()
        {
            new Validator().ValidateAndThrow(this);
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            var delay = new WaitForSeconds(_delay);

            foreach (var point in _points.RepeatForever())
            {
                yield return StartCoroutine(_movement.Move(point.position).ToCoroutine());
                yield return delay;
            }
        }

        private class Validator : AbstractValidator<LopedMovement>
        {
            public Validator()
            {
                RuleFor(move => move._points).NotNull();
                RuleFor(move => move._delay).GreaterThanOrEqualTo(0);
                RuleFor(move => move._movement).NotNull();
            }
        }
    }
}