using UnityEngine;
using DG.Tweening;
using FluentValidation;
using Source.Model;
using SwipeOrDie.Extension;

namespace SwipeOrDie.GameLogic
{
    public class CharacterMovement : ICharacterMovement
    {
        private readonly Transform _transform;
        private readonly ISpeed _speed;
        private readonly IPosition _position;
        private bool _moving;

        public CharacterMovement(Transform transform, ISpeed speed, IPosition position)
        {
            _transform = transform;
            _speed = speed;
            _position = position;

            new Validator().ValidateAndThrow(this);
        }

        public void Move(Vector2 direction)
        {
            if (!CanMove(direction))
                return;

            _moving = true;

            var nextPosition = _position.Next(direction);
            var movingTime = _transform.Time(nextPosition, _speed);

            DOTween.Sequence()
                .Append(_transform.DOMove(nextPosition, movingTime))
                .onComplete += () => _moving = false;
        }

        private bool CanMove(Vector2 direction)
        {
            return !_moving && direction != Vector2.zero;
        }

        private class Validator : AbstractValidator<CharacterMovement>
        {
            public Validator()
            {
                RuleFor(movement => movement._transform).NotNull();
                RuleFor(movement => movement._position).NotNull();
                RuleFor(movement => movement._speed).NotNull();
            }
        }
    }
}