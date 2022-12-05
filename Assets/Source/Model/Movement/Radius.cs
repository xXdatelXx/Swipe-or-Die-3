using UnityEngine;
using FluentValidation;
using SwipeOrDie.Extension;

namespace SwipeOrDie.Model
{
    public sealed class Radius : IRadius
    {
        private readonly float _value;

        public Radius(float value)
        {
            _value = value;

            new Validator().ValidateAndThrow(this);
        }

        public Vector3 Indent(Vector3 movementDirection) =>
            movementDirection.IsDirection() ? -movementDirection * _value : Vector3.zero;

        private class Validator : AbstractValidator<Radius>
        {
            public Validator() =>
                RuleFor(radius => radius._value).GreaterThanOrEqualTo(0);
        }
    }
}