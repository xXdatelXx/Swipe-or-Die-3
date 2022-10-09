using UnityEngine;
using FluentValidation;
using Sirenix.OdinInspector;
using SwipeOrDie.Data;
using SwipeOrDie.GameLogic;

namespace SwipeOrDie.Factory
{
    public class MazeFactory : SerializedMonoBehaviour, IMazeFactory
    {
        [SerializeField] private IMazeItems _items;
        [SerializeField] private Transform _enablePoint;
        [SerializeField] private Maze _activeMaze;
        private IFactory<Maze> _factory;
        private Maze _nextMaze;

        private void Awake()
        {
            _factory = new MonoBehaviourFactory<Maze>(transform);
            new Validator().ValidateAndThrow(this);
        }

        public Maze Create(IScore score)
        {
            _nextMaze = _factory.Create(_items.Get(score));
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
            }
        }
    }
}