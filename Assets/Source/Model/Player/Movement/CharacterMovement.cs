using UnityEngine;
using Zenject;
using DG.Tweening;
using FluentValidation;
using Sirenix.OdinInspector;

public class CharacterMovement : SerializedMonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _speed;
    [SerializeField] private IRadius _radius;
    private Position _position;
    private IInput _input;
    private bool _moving;

    [Inject]
    public void Construct(IInput input)
    {
        _input = input;
        _position = new Position(transform, _radius);

        new Validator().ValidateAndThrow(this);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_moving)
            return;

        _moving = true;

        var nextPosition = _position.NextByRay(_input.Direction);
        var movingTime = Vector3.Distance(transform.position, nextPosition) / _speed;

        DOTween.Sequence()
            .Append(transform.DOMove(nextPosition, movingTime))
            .onComplete += () => _moving = false;
    }

    private class Validator : AbstractValidator<CharacterMovement>
    {
        public Validator()
        {
            RuleFor(movement => movement._radius).NotNull();
            RuleFor(movement => movement._input).NotNull();
            RuleFor(movement => movement._position).NotNull();
        }
    }
}
