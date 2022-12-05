using UnityEngine;
using FluentValidation;
using JetBrains.Annotations;
using SwipeOrDie.View;

namespace SwipeOrDie.Model
{
    public sealed class CharacterMovement : ICharacterMovement
    {
        private readonly IPosition _position;
        private readonly IMovement _movement;
        [CanBeNull] private readonly IMovementView _view;
        private bool _moving;

        public CharacterMovement(Transform transform, ISpeed speed, IPosition position, IMovementView view = null)
        {
            _position = position;
            _movement = new InterpolationMovement(transform, speed);
            _view = view;

            new Validator().ValidateAndThrow(this);
        }

        public async void Move(Vector2 direction)
        {
            if (!CanMove(direction))
                return;

            _moving = true;
            _view?.OnMove(direction);
            
            await _movement.Move(_position.Next(direction));
            
            _view?.OnStop();
            _moving = false;
        }

        private bool CanMove(Vector2 direction) => direction != Vector2.zero && !_moving;

        private class Validator : AbstractValidator<CharacterMovement>
        {
            public Validator()
            {
                RuleFor(movement => movement._position).NotNull();
                RuleFor(movement => movement._movement).NotNull();
            }
        }
    }
}