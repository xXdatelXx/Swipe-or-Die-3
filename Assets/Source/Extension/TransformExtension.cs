using System;
using UnityEngine;

namespace SwipeOrDie.Extension
{
    public static class TransformExtension
    {
        public static float Distance(this Transform transform, Transform to)
        {
            if (to == null)
                throw new ArgumentNullException(nameof(to));

            return Distance(transform, to.position);
        }

        public static float Distance(this Transform position, Vector3 to)
        {
            return Vector3.Distance(position.position, to);
        }

        public static float Time(this Transform transform, Transform to, float speed)
        {
            return Time(transform, to.position, speed);
        }

        public static float Time(this Transform transform, Vector3 to, float speed)
        {
            if (speed <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(speed)} <= 0");

            return Distance(transform, to) / speed;
        }
    }
}