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
        private readonly Transform _transform;
        private bool _moving;

        public CharacterMovement(Transform transform, ISpeed speed, IPosition position, IMovementView view = null) :
            this(new InterpolationMovement(transform, speed), position, transform, view)
        {
        }

        public CharacterMovement(IMovement movement, IPosition position, Transform transform, IMovementView view = null)
        {
            _position = position;
            _movement = movement;
            _view = view;
            _transform = transform;

            new Validator().ValidateAndThrow(this);
        }

        public async void Move(Vector2 direction)
        {
            var nextPosition = _position.Next(direction);
            if (!CanMove(nextPosition))
                return;
            
            _moving = true;
            _view?.OnMove(direction);
            
            await _movement.Move(nextPosition);

            _view?.OnStop();
            _moving = false;
        }

        private bool CanMove(Vector2 nextPosition) => 
            !_transform.localPosition.Equals(nextPosition) && !_moving;

        private class Validator : AbstractValidator<CharacterMovement>
        {
            public Validator()
            {
                RuleFor(movement => movement._position).NotNull();
                RuleFor(movement => movement._movement).NotNull();
                RuleFor(movement => movement._transform).NotNull();
            }
        }
    }
}