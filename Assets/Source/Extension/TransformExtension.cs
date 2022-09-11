using System;
using Source.Model;
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

        public static float Time(this Transform transform, Transform to, ISpeed speed)
        {
            return Time(transform, to.position, speed);
        }

        public static float Time(this Transform transform, Vector3 to, ISpeed speed)
        {
            return Distance(transform, to) / speed.Value;
        }
    }
}