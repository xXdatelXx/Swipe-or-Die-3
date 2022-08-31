using UnityEngine;
using FluentValidation;

public class Position
{
    private readonly Transform _transform;
    private readonly Radius _radius;
    private readonly Validator _validator;

    public Position(Transform transform, Radius radius)
    {
        _transform = transform;
        _radius = radius;
        _validator = new();

        _validator.ValidateAndThrow(this);
    }

    public Vector3 NextByRay(Vector2 direction)
    {
        if (!_validator.ValidDirection(direction))
            return _transform.position;

        Physics.Raycast(_transform.position, direction, out var hit);

        return hit.point == Vector3.zero
            ? _transform.position
            : hit.point + _radius.Indent(direction);
    }

    private class Validator : AbstractValidator<Position>
    {
        public Validator()
        {
            RuleFor(Position => Position._transform).NotNull();
            RuleFor(Position => Position._radius).NotNull();
        }

        public bool ValidDirection(Vector2 direction)
        {
            return direction.x is 0 or 1 or -1 && direction.y is 0 or 1 or -1 && direction != Vector2.zero;
        }
    }
}
