using System.Collections.Generic;
using System.Linq;
using SwipeOrDie.Extension;
using UnityEngine;
using System;

namespace SwipeOrDie.Model
{
    [Serializable]
    public sealed class SideCollision : ISideCollision
    {
        [SerializeField] private List<int> _collisionAngles = new() { 0, 90, -90, 180 };
        [SerializeField] private Transform _transform;

        public SideCollision()
        {
            if (_collisionAngles.Count == 0)
                throw new NullReferenceException($"{nameof(_collisionAngles)}.Count == 0");
        }

        public bool TrueAngle(Collision collision)
        {
            var collisionAngle = collision.Angle(_transform);
            return _collisionAngles.Any(angle => angle == collisionAngle);
        }
    }
}