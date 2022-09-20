using UnityEngine;
using FluentValidation;
using Source.Model;
using Source.Model.Movement.Interface;

namespace SwipeOrDie.GameLogic
{
    public class CharacterMovement : ICharacterMovement
    {
        private readonly IPosition _position;
        private readonly IMovement _movement;
        private bool _moving;

        public CharacterMovement(Transform transform, ISpeed speed, IPosition position)
        {
            _position = position;
            _movement = new InterpolationMovement(transform, speed);
            
            new Validator().ValidateAndThrow(this);
        }

        public async void Move(Vector2 direction)
        {
            if (!CanMove(direction))
                return;

            _moving = true;

            await _movement.Move(_position.Next(direction));

            _moving = false;
        }

        private bool CanMove(Vector2 direction)
        {
            return !_moving && direction != Vector2.zero;
        }

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