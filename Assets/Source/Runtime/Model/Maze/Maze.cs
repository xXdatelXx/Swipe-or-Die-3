using FluentValidation;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SwipeOrDie.Model
{
    public abstract class Maze : SerializedMonoBehaviour, IMaze
    {
        [field: SerializeField] public IStartPoint StartPoint { get; private set; }

        public abstract void Init(IMovement movement, IMazeEvent mazeEvent);
        public abstract void Enable(Transform enablePosition);
        public abstract void Destroy();

        private void OnValidate() => StartPoint ??= GetComponentInChildren<IStartPoint>();

        private void OnEnable() => 
            new Validator().ValidateAndThrow(this);

        private class Validator : AbstractValidator<Maze>
        {
            public Validator()
            {
                RuleFor(maze => maze.GetComponentInChildren<IFinishPoint>()).NotNull();
                RuleFor(maze => maze.StartPoint)
                    .Equal(maze => maze.GetComponentInChildren<IStartPoint>())
                    .NotNull();
            }
        }
    }
}