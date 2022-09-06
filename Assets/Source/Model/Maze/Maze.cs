using System;
using DG.Tweening;
using UnityEngine;
using FluentValidation;
using Sirenix.OdinInspector;

namespace SwipeOrDie.GameLogic
{
    public class Maze : SerializedMonoBehaviour
    {
        [field: SerializeField] public readonly Start StartPoint;
        [SerializeField] private readonly IDestroyStrategy _destroyStrategy;
        private const float Speed = 30;

        private void Start()
        {
            new Validator(GetComponentInChildren<Start>(), GetComponentInChildren<Finish>())
                .ValidateAndThrow(this);
        }

        public void Enable(Transform enablePosition)
        {
            var nextPosition = enablePosition.position;
            var movingTime = Vector3.Distance(nextPosition, transform.position) / Speed;

            transform.DOMove(nextPosition, movingTime);
        }

        public void Destroy()
        {
            _destroyStrategy.Destroy();
        }

        private class Validator : AbstractValidator<Maze>
        {
            public Validator(Start childStart, Finish childFinish)
            {
                if (childStart == null)
                    throw new NullReferenceException("Dont have Start in child");
                if (childFinish == null)
                    throw new NullReferenceException("Dont have Finish in child");

                RuleFor(maze => maze.StartPoint).Equal(childStart).WithMessage($"{nameof(StartPoint)} must be child");
                RuleFor(maze => maze.StartPoint).NotNull();
                RuleFor(maze => maze._destroyStrategy).NotNull();
            }
        }
    }
}
