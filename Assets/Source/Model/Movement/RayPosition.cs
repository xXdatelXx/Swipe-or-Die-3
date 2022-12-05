using UnityEngine;
using FluentValidation;
using SwipeOrDie.Extension;
using System.Linq;
using SwipeOrDie.Model.Part;

namespace SwipeOrDie.Model
{
    public sealed class RayPosition : IPosition
    {
        private readonly Transform _transform;
        private readonly IRadius _radius;
        private readonly Validator _validator;

        public RayPosition(Transform transform, IRadius radius)
        {
            _transform = transform;
            _radius = radius;
            _validator = new();

            _validator.ValidateAndThrow(this);
        }

        public Vector3 Next(Vector2 direction)
        {
            if (!_validator.ValidDirection(direction))
                return _transform.position;

            var hit = Physics
                .RaycastAll(_transform.position, _transform.TransformDirection(direction))
                .OrderBy(i => _transform.Distance(i.point))
                .First(j => _validator.ValidHit(j)).point;
            
            return hit != Vector3.zero
                ? hit + _transform.TransformDirection(_radius.Indent(direction))
                : _transform.localPosition;
        }

        private class Validator : AbstractValidator<RayPosition>
        {
            public Validator()
            {
                RuleFor(Position => Position._transform).NotNull();
                RuleFor(Position => Position._radius).NotNull();
            }

            public bool ValidDirection(Vector2 direction) =>
                direction.x is 0 or 1 or -1 && direction.y is 0 or 1 or -1 && direction != Vector2.zero;

            public bool ValidHit(RaycastHit hit) =>
                hit.Is<IBorder>() || hit.point == Vector3.zero;
        }
    }
}