using UnityEngine;
using FluentValidation;
using Sirenix.OdinInspector;
using SwipeOrDie.Data;
using SwipeOrDie.Model;

namespace SwipeOrDie.Factory
{
    public sealed class MazeFactory : SerializedMonoBehaviour, IMazeFactory
    {
        [SerializeField] private IMazeItems _items;
        [SerializeField] private IMazeEvents _events;
        [SerializeField] private Transform _enablePoint;
        [SerializeField] private Maze _activeMaze;
        [ShowInInspector, ReadOnly] private ISpeed _speed = new Speed(30);
        private IGenericFactory<Maze> _factory;
        private Maze _nextMaze;

        private void Awake()
        {
            _factory = new MonoBehaviourFactory<Maze>(transform);
            new Validator().ValidateAndThrow(this);
        }

        public IMaze Create()
        {
            _nextMaze = _factory.Create(_items.Get());
            _nextMaze.Init(new InterpolationMovement(_nextMaze.transform, _speed), _events.Get(_nextMaze));
            Logger.Log(_nextMaze.name);
            return _activeMaze;
        }

        public void Destroy()
        {
            if (_activeMaze == null)
                return;

            _activeMaze.Destroy();
            _nextMaze.Enable(_enablePoint);
            _activeMaze = _nextMaze;
        }

        private class Validator : AbstractValidator<MazeFactory>
        {
            public Validator()
            {
                RuleFor(factory => factory._factory).NotNull();
                RuleFor(factory => factory._items).NotNull();
                RuleFor(factory => factory._enablePoint).NotNull();
                RuleFor(factory => factory._activeMaze).NotNull();
                RuleFor(factory => factory._events).NotNull();
            }
        }
    }
}