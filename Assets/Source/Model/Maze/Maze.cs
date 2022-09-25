using UnityEngine;
using FluentValidation;
using Sirenix.OdinInspector;
using Source.Model;
using Source.Model.Movement.Interface;

namespace SwipeOrDie.GameLogic
{
    public class Maze : SerializedMonoBehaviour
    {
        [SerializeField] private IDestroyStrategy _destroyStrategy;
        [SerializeField] private IMazeEvent _event;
        [SerializeField, ReadOnly] private readonly ISpeed _speed = new Speed(30);
        private IMovement _movement;
        public readonly IStartPoint StartPoint;

        private void Start()
        {
            _movement = new InterpolationMovement(transform, _speed);
            new Validator().ValidateAndThrow(this);
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
            public Validator()
            {
                RuleFor(maze => maze._destroyStrategy).NotNull();
                RuleFor(maze => maze._movement).NotNull();
                RuleFor(maze => maze._event).NotNull();
                //RuleFor(maze => maze.GetComponent<IFinishPoint>()).NotNull();
                //RuleFor(maze => maze.StartPoint)
                //    .Equal(maze => maze.StartPoint)
                //    .NotNull();
            }
        }
    }
}