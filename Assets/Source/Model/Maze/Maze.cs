using System;
using UnityEngine;
using FluentValidation;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Source.Model;
using Source.Model.Movement.Interface;

namespace SwipeOrDie.GameLogic
{
    public class Maze : SerializedMonoBehaviour
    {
        [SerializeField] private IDestroyStrategy _destroyStrategy;
        [SerializeField] private IMazeEvent _event;
        private readonly ISpeed _speed = new Speed(30);
        public readonly IStartPoint StartPoint;
        private IMovement _movement;

        private void Start()
        {
            _movement = new InterpolationMovement(transform, _speed);
            _event ??= new MazeEvent();
            
            new Validator(GetComponentInChildren<IStartPoint>(), GetComponentInChildren<IFinishPoint>())
                .ValidateAndThrow(this);
        }

        public void Enable(Transform enablePosition)
        {
            _event.OnMazeEnabled();
            _movement.Move(enablePosition.position);
        }

        public void Destroy()
        {
            _destroyStrategy.Destroy();
        }

        private class Validator : AbstractValidator<Maze>
        {
            public Validator(IStartPoint childStart, IFinishPoint childFinish)
            {
                if (childStart == null)
                    throw new NullReferenceException("Dont have Start in child");
                if (childFinish == null)
                    throw new NullReferenceException("Dont have Finish in child");

                RuleFor(maze => maze._destroyStrategy).NotNull();
                RuleFor(maze => maze._movement).NotNull();
                RuleFor(maze => maze._event).NotNull();
                RuleFor(maze => maze.StartPoint)
                    .Equal(childStart).WithMessage($"{nameof(StartPoint)} must be child")
                    .NotNull();
            }
        }
    }
}