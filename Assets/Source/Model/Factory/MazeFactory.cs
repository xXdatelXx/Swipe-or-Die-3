using UnityEngine;
using FluentValidation;
using Sirenix.OdinInspector;
using SwipeOrDie.Data;
using SwipeOrDie.GameLogic;

namespace SwipeOrDie.Factory
{
    public class MazeFactory : SerializedMonoBehaviour
    {
        [SerializeField] private MazeItems _items;
        [SerializeField] private Transform _enablePoint;
        [SerializeField] private Maze _previousMaze;
        private IFactory<Maze> _factory;
        private Maze _nextMaze;

        private void Awake()
        {
            _factory = new MonoBehaviourFactory<Maze>(transform);
            new Validator().ValidateAndThrow(this);
        }

        private void Start()
        {
            Create(new Score());
        }

        public Maze Create(Score score)
        {
            _nextMaze = _factory.Create(_items.Get(score));

            return _previousMaze;
        }

        public void Destroy()
        {
            if (_previousMaze == null)
                return;

            _previousMaze.Destroy();
            _nextMaze.Enable(_enablePoint);
            _previousMaze = _nextMaze;
        }

        private class Validator : AbstractValidator<MazeFactory>
        {
            public Validator()
            {
                RuleFor(factory => factory._factory).NotNull();
                RuleFor(factory => factory._items).NotNull();
                RuleFor(factory => factory._enablePoint).NotNull();
                RuleFor(factory => factory._previousMaze).NotNull();
            }
        }
    }
}
