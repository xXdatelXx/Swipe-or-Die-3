using UnityEngine;
using FluentValidation;
using Sirenix.OdinInspector;

public class MazeFactory : SerializedMonoBehaviour
{
    [SerializeField] private IMonoBehaviourFactory _factory;
    [SerializeField] private MazeItems _items;
    [SerializeField] private Transform _enablePoint;
    [SerializeField] private Maze _previousMaze;
    private Maze _nextMaze;

    private void Awake()
    {
        new Validator().ValidateAndThrow(this);
    }

    private void Start()
    {
        Create(new Score());
    }

    public Maze Create(IScore score)
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
