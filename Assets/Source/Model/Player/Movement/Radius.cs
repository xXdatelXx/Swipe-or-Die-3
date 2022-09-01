using UnityEngine;
using FluentValidation;

public class Radius : IRadius
{
    private float _value;

    public Radius(float value)
    {
        _value = value;

        new Validator().ValidateAndThrow(this);
    }

    public Vector3 Indent(Vector3 movementDirection)
    {
        if (!movementDirection.IsDirection())
            return Vector3.zero;

        var indent = Vector3.one.Multiply(-movementDirection) * _value;

        return indent;
    }

    private class Validator : AbstractValidator<Radius>
    {
        public Validator()
        {
            RuleFor(radius => radius._value).GreaterThanOrEqualTo(0);
        }
    }
}
