using UnityEngine;
using DG.Tweening;
using FluentValidation;

public class CharacterMovement : ICharacterMovement
{
    private Transform _transform;
    private float _speed;
    private IPosition _position;
    private bool _moving;

    public CharacterMovement(Transform transform, float speed, IPosition position)
    {
        _transform = transform;
        _speed = speed;
        _position = position;

        new Validator().ValidateAndThrow(this);
    }

    public void Move(Vector2 direction)
    {
        if (_moving)
            return;

        _moving = true;

        var nextPosition = _position.Next(direction);
        var movingTime = Vector3.Distance(_transform.position, nextPosition) / _speed;

        DOTween.Sequence()
            .Append(_transform.DOMove(nextPosition, movingTime))
            .onComplete += () => _moving = false;
    }

    private class Validator : AbstractValidator<CharacterMovement>
    {
        public Validator()
        {
            RuleFor(movement => movement._transform).NotNull();
            RuleFor(movement => movement._speed).GreaterThan(0);
            RuleFor(movement => movement._position).NotNull();
        }
    }
}
