using UnityEngine;
using FluentValidation;

public class MazeFactory : MonoBehaviour
{
    [SerializeField, Range(0.1f, 100)] private float _mazeSpeed = 0.1f;
    [SerializeField] private MonoBehaviourFactory _factory;
    [SerializeField] private MazeItems _items;
    [SerializeField] private Transform _enablePoint;
    [SerializeField] private Maze _previousMaze;
    private Maze _nextMaze;

    private void Awake()
    {
        new Validator().ValidateAndThrow(this);

        _previousMaze.Init(_mazeSpeed);
    }

    private void Start()
    {
        Create(new Score());
    }

    public Maze Create(Score score)
    {
        _nextMaze = _factory.Create(_items.Get(score));
        _nextMaze.Init(_mazeSpeed);

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
            RuleFor(factory => factory._mazeSpeed).GreaterThan(0);
            RuleFor(factory => factory._factory).NotNull();
            RuleFor(factory => factory._items).NotNull();
            RuleFor(factory => factory._enablePoint).NotNull();
            RuleFor(factory => factory._previousMaze).NotNull();
        }
    }
}
